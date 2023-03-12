using System.Collections;
using Microsoft.AspNetCore.Mvc;
using BasketAPI.Models;
using BasketAPI.Data;

namespace BasketAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private BasketContext _dbContext;
    private ProductValidator _validator;

    public BasketController(BasketContext dbContext)
    {
        _dbContext = dbContext;
        _validator = new ProductValidator();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var baskets = _dbContext.Baskets.ToList();
        return Ok(baskets);
    }

    /// <summary>
    /// Get basket from sessionId
    /// </summary>
    /// <param name="sessionId"></param>
    /// <returns></returns>
    [HttpGet("{sessionId}")]
    public IActionResult GetById(string sessionId)
    {
        var basket = _dbContext.Baskets.ToList();
        return Ok(basket);
    }

    /// <summary>
    /// Add item to basket, create new if doesnt exist
    /// </summary>
    /// <returns></returns>
    [HttpPut("{sessionId}/items")]
    public IActionResult Put(string sessionId, BasketItem item)
    {

        var basket = _dbContext.Baskets.Where(b => b.SessionId == sessionId);
        if (basket != null)
        {

        }
        else
        {

        }
        return Ok();
    }

    [HttpDelete("{sessionId}/{basketItemId}")]
    public IActionResult Delete(string sessionId, int basketItemId)
    {
        return Ok();
    }
}