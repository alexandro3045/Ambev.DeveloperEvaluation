using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.Product;

/// <summary>
/// Contains unit tests for the Product entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class ProductTests
{
    /// <summary>
    /// Tests that validation passes when all Product properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid Product data")]
    public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var Product = ProductTestData.GenerateValidProduct();

        // Act
        var result = Product.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when Product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid Product Title")]
    public void Given_InvalidProductData_When_InValidatedTitle_Then_ShouldReturnInvalid()
    {
        // Arrange
        var Product = ProductTestData.GenerateInValidProduct("Title");

        // Act
        var result = Product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }

    /// <summary>
    /// Tests that validation fails when Product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid Product price")]
    public void Given_InvalidProductData_When_InValidatedPrice_Then_ShouldReturnInvalid()
    {
        // Arrange
        var Product = ProductTestData.GenerateInValidProduct("Price", 0);

        // Act
        var result = Product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }

    /// <summary>
    /// Tests that validation fails when Product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid Product Description")]
    public void Given_InvalidProductData_When_InValidatedDescription_Then_ShouldReturnInvalid()
    {
        // Arrange
        var Product = ProductTestData.GenerateInValidProduct("Description");

        // Act
        var result = Product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }

    /// <summary>
    /// Tests that validation fails when Product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid Product Category")]
    public void Given_InvalidProductData_When_InValidatedCategory_Then_ShouldReturnInvalid()
    {
        // Arrange
        var Product = ProductTestData.GenerateInValidProduct("Category");

        // Act
        var result = Product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }

    /// <summary>
    /// Tests that validation fails when Product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid Product Image")]
    public void Given_InvalidProductData_When_InValidatedImage_Then_ShouldReturnInvalid()
    {
        // Arrange
        var Product = ProductTestData.GenerateInValidProduct("Image");

        // Act
        var result = Product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }

    /// <summary>
    /// Tests that validation fails when Product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid Product CreatedAt")]
    public void Given_InvalidProductData_When_InValidatedCreatedAt_Then_ShouldReturnInvalid()
    {
        // Arrange
        var Product = ProductTestData.GenerateInValidProduct("CreatedAt", new DateTime());

        // Act
        var result = Product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }
}
