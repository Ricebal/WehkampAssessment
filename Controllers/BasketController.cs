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

    [HttpGet(Name = "basket")]
    public IEnumerable<Basket> Get()
    {
        return null;
    }
}
