using BasketAPI.Models;

namespace BasketAPI;

public class PriceCalculator
{
    private readonly int _lowShippingPrice = 250;
    private readonly int _mediumShippingPrice = 500;
    private readonly int _highShippingPrice = 750;

    public int GetShippingCosts(int amountOfProducts)
    {
        if (amountOfProducts > 5)
        {
            return _highShippingPrice;
        }
        else if (amountOfProducts > 1)
        {
            return _mediumShippingPrice;
        }
        else if (amountOfProducts == 1)
        {
            return _lowShippingPrice;
        }
        else
        {
            throw new InvalidDataException();
        }
    }

    public Basket SetPrices(Basket basket)
    {
        int totalProducts = 0;
        int totalPrice = 0;
        basket.Items.ForEach(basketItem =>
        {
            totalProducts += basketItem.NumberOfProducts;
            totalPrice += basketItem.TotalPrice;
        });

        basket.ShippingCosts = GetShippingCosts(totalProducts);
        basket.TotalPrice = basket.ShippingCosts + totalPrice;
        return basket;
    }
}