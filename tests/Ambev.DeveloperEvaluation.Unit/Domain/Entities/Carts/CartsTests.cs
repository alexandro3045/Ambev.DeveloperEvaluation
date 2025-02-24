using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.Carts;

/// <summary>
/// Contains unit tests for the Carts entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SalesCartsTests
{
    /// <summary>
    /// Tests that validation passes when all Carts properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid Carts data")]
    public void Given_ValidCartsData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var Carts = CartsTestData.GenerateValidCarts();

        // Act
        var result = Carts.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when Carts properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid Carts Products")]
    public void Given_InvalidCartsData_When_InValidatedProducts_Then_ShouldReturnInvalid()
    {
        // Arrange
        // Arrange
        var Carts = CartsTestData.GenerateInValidProductsCarts();

        // Act
        var result = Carts.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }

    /// <summary>
    /// Tests that validation fails when Carts properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid Carts UserId")]
    public void Given_InvalidCartsData_When_InValidatedUserId_Then_ShouldReturnInvalid()
    {
        // Arrange
        // Arrange
        var Carts = CartsTestData.GenerateInValidUserIdCarts();

        // Act
        var result = Carts.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);

    }
}
