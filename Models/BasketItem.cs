namespace BasketAPI;

public class BasketItem
{
    public int BasketItemId { get; set; }
    public Product Product { get; set; }
    public int Size { get; set; }
    public int NumberOfProducts { get; set; }
    public int TotalPrice => Product.Price * NumberOfProducts;
}