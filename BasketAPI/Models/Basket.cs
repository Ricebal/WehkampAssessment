namespace BasketAPI.Models;

public class Basket
{
    public int BasketId { get; set; }
    public string SessionId { get; set; }
    public BasketItem[] Items { get; set; }
    public int ShippingCosts { get; set; }
    public int TotalPrice { get; set; }
}
