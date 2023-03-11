using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private readonly ILogger<BasketController> _logger;
    private readonly List<Product> _store = new List<Product>{
        new Product { ProductId = 16030998, Name = "Puma T-Shirt", Price = 1995 },
        new Product { ProductId = 801244, Name = "WE Fashion T-Shirt", Price = 1299 },
        new Product { ProductId = 755850, Name = "Mc Queen regular fit bermuda", Price = 5500 },
        new Product { ProductId = 967840, Name = "Lego BrickHeadz 41614 Owen & Blue", Price = 1999 },
        new Product { ProductId = 16076948, Name = "The Hitchhiker's Guide to the Galaxy", Price = 2299 },
        new Product { ProductId = 16049675, Name = "Rode galajurk", Price = 11999 },
        new Product { ProductId = 478271, Name = "Matrix trilogy (Blu-ray)", Price = 5699 },
        new Product { ProductId = 900277, Name = "Nintendo Switch blauw/rood", Price = 32900 },
        new Product { ProductId = 332391, Name = "Apple iPhone X 265gb", Price = 132900},
        new Product { ProductId = 829721, Name = "JBL E55 over-ear bluetooth koptelefoon zwart", Price = 11900 },
        new Product { ProductId = 858445, Name = "Red Dead Redemption 2 (PS4)", Price = 5999 },
        new Product { ProductId = 460865, Name = "Amplified - Rolling Stones T-shirt", Price = 2999 }
    };

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
