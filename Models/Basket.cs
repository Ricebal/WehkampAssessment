namespace BasketAPI;

public class Basket
{
    public string SessionId { get; set; }
    public BasketItem[] Items { get; set; }
    public int ShippingCosts { get; set}
    public int TotalPrice { get; set; }
}
