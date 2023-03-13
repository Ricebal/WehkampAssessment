using System.Collections;
using Microsoft.AspNetCore.Mvc;
using BasketAPI.Models;
using BasketAPI.Data;
using BasketAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private BasketContext _dbContext;
    private ProductValidator _productValidator;
    private PriceCalculator _priceCalculator;

    public BasketController(BasketContext dbContext)
    {
        _dbContext = dbContext;
        _productValidator = new ProductValidator();

        // For testing purposes
        if (_dbContext.Products.ToList().Count < 1)
        {
            _productValidator.PopulateDB(dbContext);
        }

        _priceCalculator = new PriceCalculator();
    }

    /// <summary>
    /// Get all baskets
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAll()
    {
        var baskets = _dbContext.Baskets.Include(b => b.Items).ThenInclude(i => i.Product).ToList();
        return Ok(baskets);
    }

    /// <summary>
    /// Get basket from sessionId
    /// </summary>
    /// <returns></returns>
    [HttpGet("{sessionId}")]
    public IActionResult GetById(string sessionId)
    {
        var basket = _dbContext.Baskets.Include(b => b.Items).ThenInclude(i => i.Product).Where(b => b.SessionId == sessionId).FirstOrDefault();
        if (basket != null)
        {
            return Ok(basket);
        }

        return BadRequest();
    }

    /// <summary>
    /// Add item to basket, create new if doesnt exist
    /// </summary>
    /// <returns></returns>
    [HttpPut("{sessionId}/items")]
    public IActionResult Put(string sessionId, [FromBody] BasketItemForPutDto item)
    {
        var product = _dbContext.Products.Where(p => p.ProductId == item.ProductId).FirstOrDefault();
        if (product != null && _productValidator.IsValid(product))
        {
            var basket = _dbContext.Baskets.Include(b => b.Items).ThenInclude(i => i.Product).Where(b => b.SessionId == sessionId).FirstOrDefault();
            if (basket != null)
            {
                basket.Items.Add(new BasketItem { Size = item.Size, NumberOfProducts = item.NumberOfProducts, Product = product });

                int totalProducts = 0;
                int totalPrice = 0;
                basket.Items.ForEach(basketItem =>
                {
                    totalProducts += basketItem.NumberOfProducts;
                    totalPrice += basketItem.TotalPrice;
                });

                basket.ShippingCosts = _priceCalculator.GetShippingCosts(totalProducts);
                basket.TotalPrice = basket.ShippingCosts + totalPrice;

                _dbContext.SaveChanges();
                return GetById(basket.SessionId);
            }
            else
            {
                Basket newBasket = new Basket { SessionId = sessionId, Items = new List<BasketItem> { new BasketItem { Size = item.Size, NumberOfProducts = item.NumberOfProducts, Product = product } } };
                newBasket.ShippingCosts = _priceCalculator.GetShippingCosts(item.NumberOfProducts);
                newBasket.TotalPrice = newBasket.ShippingCosts + (product.Price * item.NumberOfProducts);

                _dbContext.Add(newBasket);
                _dbContext.SaveChanges();
                return GetById(newBasket.SessionId);
            }
        }

        return BadRequest();
    }

    [HttpDelete("{sessionId}/{basketItemId}")]
    public IActionResult Delete(string sessionId, int basketItemId)
    {
        return Ok();
    }
}