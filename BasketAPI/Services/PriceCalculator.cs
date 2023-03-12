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
}