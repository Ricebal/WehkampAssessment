using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BasketAPI.Models;

public class BasketItem
{
    [Key]
    [Column("basket_item_id")]
    [JsonPropertyName("basket_item_id")]
    public int BasketItemId { get; set; }
    [Column("product")]
    [JsonPropertyName("product")]
    public virtual Product Product { get; set; }
    [Column("size")]
    [JsonPropertyName("size")]
    public string? Size { get; set; }
    [Column("number_of_products")]
    [JsonPropertyName("number_of_products")]
    public int NumberOfProducts { get; set; }
    [Column("total_price")]
    [JsonPropertyName("total_price")]
    public int TotalPrice => Product.Price * NumberOfProducts;
    [JsonIgnore]
    [Column("basket_id")]
    public int BasketId { get; set; }
}