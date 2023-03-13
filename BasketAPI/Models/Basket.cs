using System.ComponentModel.DataAnnotations;

namespace BasketAPI.Models;

public class Basket
{
    [Key]
    public int BasketId { get; set; }
    public string SessionId { get; set; }
    public virtual List<BasketItem> Items { get; set; }
    public int ShippingCosts { get; set; }
    public int TotalPrice { get; set; }
}
