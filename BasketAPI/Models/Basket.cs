using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BasketAPI.Models;

public class Basket
{
    [Key]
    [JsonIgnore]
    [Column("basket_id")]
    public int BasketId { get; set; }
    [Column("session_id")]
    [JsonPropertyName("session_id")]
    public string SessionId { get; set; }
    [Column("items")]
    [JsonPropertyName("items")]
    public virtual List<BasketItem> Items { get; set; }
    [Column("shipping_costs")]
    [JsonPropertyName("shipping_costs")]
    public int ShippingCosts { get; set; }
    [Column("total_price")]
    [JsonPropertyName("total_price")]
    public int TotalPrice { get; set; }
}
