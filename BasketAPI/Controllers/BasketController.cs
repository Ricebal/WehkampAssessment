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

        // For testing purposes, populate the database with products if it's empty
        if (_dbContext.Products.ToList().Count < 1)
        {
            _productValidator.PopulateDB(dbContext);
        }

        _priceCalculator = new PriceCalculator();
    }

    /// <summary>
    /// Get all baskets
    /// </summary>
    /// <returns>Every basket that exists</returns>
    [HttpGet]
    public IActionResult GetAll()
    {
        var baskets = _dbContext.Baskets.Include(b => b.Items).ThenInclude(i => i.Product).ToList();
        return Ok(baskets);
    }

    /// <summary>
    /// Get basket from session ID
    /// </summary>
    /// <returns>A signle basket based on ID provided</returns>
    [HttpGet("{session_id}")]
    public IActionResult GetById(string session_id)
    {
        var basket = _dbContext.Baskets.Include(b => b.Items).ThenInclude(i => i.Product).Where(b => b.SessionId == session_id).FirstOrDefault();
        if (basket != null)
        {
            return Ok(basket);
        }

        return BadRequest();
    }

    /// <summary>
    /// Add item to basket, create a new one if there isn't a basket with the session ID
    /// </summary>
    /// <returns>Array of the added basket item IDs</returns>
    [HttpPut("{session_id}/items")]
    public IActionResult Put(string session_id, [FromBody] List<BasketItemForPutDto> items)
    {
        var basket = _dbContext.Baskets.Include(b => b.Items).ThenInclude(i => i.Product).Where(b => b.SessionId == session_id).FirstOrDefault();
        if (basket == null)
        {
            basket = new Basket { SessionId = session_id, Items = new List<BasketItem>() };
            _dbContext.Add(basket);
        }
        List<BasketItem> itemsToAdd = new List<BasketItem>();
        items.ForEach(item =>
        {
            var product = _dbContext.Products.Where(p => p.ProductId == item.ProductId).FirstOrDefault();
            if (product != null && _productValidator.IsValid(product))
            {
                BasketItem itemToAdd = new BasketItem { Size = item.Size, NumberOfProducts = item.NumberOfProducts, Product = product };
                itemsToAdd.Add(itemToAdd);
            }
        });

        basket.Items.AddRange(itemsToAdd);
        basket = _priceCalculator.SetPrices(basket);
        List<int> addedIds = new List<int>();
        _dbContext.SaveChanges();
        addedIds.AddRange(itemsToAdd.Select(item => item.BasketItemId));
        return Ok(addedIds);
    }

    /// <summary>
    /// Remove an item from a basket using session and basket item id
    /// </summary>
    /// <returns>The basket that the item was removed from</returns>
    [HttpDelete("{session_id}/{basket_item_id:int}")]
    public IActionResult Delete(string session_id, int basket_item_id)
    {
        var basket = _dbContext.Baskets.Include(b => b.Items).ThenInclude(i => i.Product).Where(b => b.SessionId == session_id).FirstOrDefault();
        if (basket != null)
        {
            BasketItem itemToRemove = basket.Items.Find(basketItem => basketItem.BasketItemId == basket_item_id);
            if (itemToRemove != null)
            {
                basket.Items.Remove(itemToRemove);
                basket = _priceCalculator.SetPrices(basket);

                _dbContext.SaveChanges();
                return Ok(basket);
            }
            return NotFound(basket);
        }

        return BadRequest();
    }
}