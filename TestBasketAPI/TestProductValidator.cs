using BasketAPI;
using BasketAPI.Models;
using FluentAssertions;

namespace TestBasketAPI;

public class TestProductValidator
{
    private ProductValidator _productValidator;

    public TestProductValidator()
    {
        _productValidator = new ProductValidator();
    }

    [Theory]
    [InlineData(16049675, "Rode galajurk", 11999)]
    [InlineData(900277, "Nintendo Switch blauw/rood", 32900)]
    [InlineData(460865, "Amplified - Rolling Stones T-shirt", 2999)]
    public void ReturnTrueWhenValid(int productId, string name, int price)
    {
        // Arrange
        Product product = new Product { ProductId = productId, Name = name, Price = price };
        bool actual;

        // Act
        actual = _productValidator.IsValid(product);

        // Assert
        actual.Should().BeTrue();
    }

    [Theory]
    [InlineData(1, "Blauwe galajurk", 5)]
    [InlineData(478271, "Matrix trilogy (Blu-ray)", 5690)]
    [InlineData(332391, "Appel iPhone X 264gb", 132900)]
    [InlineData(478271, "Puma T-Shirt", 1995)]
    public void ReturnFalseWhenInvalid(int productId, string name, int price)
    {
        // Arrange
        Product product = new Product { ProductId = productId, Name = name, Price = price };
        bool actual;

        // Act
        actual = _productValidator.IsValid(product);

        // Assert
        actual.Should().BeFalse();
    }
}