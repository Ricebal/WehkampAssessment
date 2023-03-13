using System.ComponentModel.DataAnnotations;

namespace BasketAPI.DTO;

public class BasketItemForPutDto
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public int NumberOfProducts { get; set; }

    public int Size { get; set; }
}