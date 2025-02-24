using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.SalesCarts;

/// <summary>
/// Contains unit tests for the SalesCarts entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SalesCartsTests
{
    /// <summary>
    /// Tests that validation passes when all SalesCarts properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid SalesCarts data")]
    public void Given_ValidSalesCartsData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var SalesCarts = SalesCartsTestData.GenerateValidSalesCarts();

        // Act
        var result = SalesCarts.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when SalesCarts properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid SalesCarts Products")]
    public void Given_InvalidSalesCartsData_When_InValidatedProducts_Then_ShouldReturnInvalid()
    {
        // Arrange
        // Arrange
        var SalesCarts = SalesCartsTestData.GenerateInValidProductsSalesCarts();

        // Act
        var result = SalesCarts.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }

    /// <summary>
    /// Tests that validation fails when SalesCarts properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid SalesCarts UserId")]
    public void Given_InvalidSalesCartsData_When_InValidatedUserId_Then_ShouldReturnInvalid()
    {
        // Arrange
        // Arrange
        var SalesCarts = SalesCartsTestData.GenerateInValidUserIdSalesCarts();

        // Act
        var result = SalesCarts.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when SalesCarts properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid SalesCarts BranchId")]
    public void Given_InvalidSalesCartsData_When_InValidatedBranchId_Then_ShouldReturnInvalid()
    {
        // Arrange
        // Arrange
        var SalesCarts = SalesCartsTestData.GenerateInValidBranchIdSalesCarts();

        // Act
        var result = SalesCarts.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when SalesCarts properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid SalesCarts SalesNumber")]
    public void Given_InvalidSalesCartsData_When_InValidatedSalesNumber_Then_ShouldReturnInvalid()
    {
        // Arrange
        // Arrange
        var SalesCarts = SalesCartsTestData.GenerateInValidSalesNumberSalesCarts();

        // Act
        var result = SalesCarts.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when SalesCarts properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid SalesCarts Carts")]
    public void Given_InvalidSalesCartsData_When_InValidatedCarts_Then_ShouldReturnInvalid()
    {
        // Arrange
        var SalesCarts = SalesCartsTestData.GenerateInValidCartsSalesCarts();

        // Act
        var result = SalesCarts.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when SalesCarts properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for valid calculate SalesCarts Carts")]
    public void Given_InvalidSalesCartsData_When_ValidatedSaleCartCalculate_Then_ShouldReturnInvalid()
    {
        // Arrange
        var SalesCarts = SalesCartsTestData.GenerateValidSalesCarts();

        SalesCarts.CalculateCart();

        Assert.True(SalesCarts.Quantities == 5);

        Assert.True(SalesCarts.TotalSalesAmount == 21900);

        Assert.True(SalesCarts.Canceled == false);

        //4 unities de produto zero discounts
        Assert.True(SalesCarts.Carts.CartsProductsItems.Where(p => p.Quantity < 4).First().Discounts == 0);

        //10 e 20 unities de produto 20% discounts
        Assert.True(SalesCarts.Carts.CartsProductsItems.Where(p => p.Quantity >= 10 && p.Quantity <= 20).First().Discounts == 600);

        //You cannot sell more than 20 units of the same product
        Assert.True(SalesCarts.Carts.CartsProductsItems.Where(p => p.Quantity == 20).First().Discounts == 1600);
    }
}
