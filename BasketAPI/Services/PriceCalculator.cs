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
            return 750;
        }
        else if (amountOfProducts > 1)
        {
            return 500;
        }
        else if (amountOfProducts == 1)
        {
            return 250;
        }
        else
        {
            throw new InvalidDataException();
        }
    }
}