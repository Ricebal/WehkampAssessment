using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BasketAPI.DTO;

public class BasketItemForPutDto
{
    [Required]
    [JsonPropertyName("product_id")]
    public int ProductId { get; set; }

    [Required]
    [JsonPropertyName("number_of_products")]
    public int NumberOfProducts { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }
}