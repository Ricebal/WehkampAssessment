using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketAPI.Models;

public class BasketItem
{
    [Key]
    public int BasketItemId { get; set; }
    public int? Size { get; set; }
    public int NumberOfProducts { get; set; }
    public int TotalPrice => Product.Price * NumberOfProducts;
    public virtual Product Product { get; set; }
    public int BasketId { get; set; }
}