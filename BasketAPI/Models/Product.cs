using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BasketAPI.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("id")]
    [JsonPropertyName("id")]
    public int ProductId { get; set; }
    [Column("description")]
    [JsonPropertyName("description")]
    public string Name { get; set; }
    [Column("price")]
    [JsonPropertyName("price")]
    public int Price { get; set; }
}