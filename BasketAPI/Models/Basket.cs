using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BasketAPI.Models;

public class Basket
{
    [Key]
    [JsonIgnore]
    public int BasketId { get; set; }
    public string SessionId { get; set; }
    public virtual List<BasketItem> Items { get; set; }
    public int ShippingCosts { get; set; }
    public int TotalPrice { get; set; }
}
