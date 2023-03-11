using BasketAPI;
using FluentAssertions;

namespace TestBasketAPI;

public class TestShippingCosts
{
    private PriceCalculator _priceCalculator;

    public TestShippingCosts()
    {
        _priceCalculator = new PriceCalculator();
    }

    [Fact]
    public void Return250When1()
    {
        // Arrange
        int amountOfProducts = 1;
        int expectedPrice = 250;
        int actualPrice;

        // Act
        actualPrice = _priceCalculator.GetShippingCosts(amountOfProducts);

        // Assert
        actualPrice.Should().Be(expectedPrice);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Return500WhenBetween2And5(int amountOfProducts)
    {
        // Arrange
        int expectedPrice = 500;
        int actualPrice;

        // Act
        actualPrice = _priceCalculator.GetShippingCosts(amountOfProducts);

        // Assert
        actualPrice.Should().Be(expectedPrice);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(25)]
    public void Return750WhenMoreThan5Products(int amountOfProducts)
    {
        // Arrange
        int expectedPrice = 750;
        int actualPrice;

        // Act
        actualPrice = _priceCalculator.GetShippingCosts(amountOfProducts);

        // Assert        
        actualPrice.Should().Be(expectedPrice);
    }
}