using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BasketAPI.Models;

public class BasketItem
{
    [Key]
    public int BasketItemId { get; set; }
    public virtual Product Product { get; set; }
    public int? Size { get; set; }
    public int NumberOfProducts { get; set; }
    public int TotalPrice => Product.Price * NumberOfProducts;
    [JsonIgnore]
    public int BasketId { get; set; }
}