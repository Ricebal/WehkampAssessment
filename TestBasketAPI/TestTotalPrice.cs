using BasketAPI;
using BasketAPI.Models;
using FluentAssertions;

namespace TestBasketAPI;

public class TestTotalPrice
{
    private PriceCalculator _priceCalculator;

    public TestTotalPrice()
    {
        _priceCalculator = new PriceCalculator();
    }

    [Fact]
    public void ReturnCorrectValue1Product()
    {
        // Arrange
        int expected = 6498;
        Basket basket = new Basket();
        basket.Items = new List<BasketItem>();
        basket.Items.Add(new BasketItem { Product = new Product { Price = 2999 }, NumberOfProducts = 2 });

        // Act
        basket = _priceCalculator.SetPrices(basket);

        // Assert
        basket.TotalPrice.Should().Be(expected);
    }

    [Fact]
    public void ReturnCorrectValueMultipleProducts()
    {
        // Arrange
        int expected = 19243;
        Basket basket = new Basket();
        basket.Items = new List<BasketItem>();
        basket.Items.Add(new BasketItem { Product = new Product { Price = 2999 }, NumberOfProducts = 2 });
        basket.Items.Add(new BasketItem { Product = new Product { Price = 2499 }, NumberOfProducts = 5 });

        // Act
        basket = _priceCalculator.SetPrices(basket);

        // Assert
        basket.TotalPrice.Should().Be(expected);
    }
}