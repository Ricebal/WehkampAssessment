using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private readonly ILogger<BasketController> _logger;
    public BasketController(ILogger<BasketController> logger)
    {
        _logger = logger;
    }

    /// <summary>  
    /// Create a Product  
    /// </summary>
    /// <remarks>  
    /// Create a product into Databse  
    /// </remarks>  
    /// <returns></returns>  
    [HttpGet(Name = "basket/{sessionId}")]
    public IEnumerable<Basket> Get(string sessionId)
    {
        return null;
    }
}