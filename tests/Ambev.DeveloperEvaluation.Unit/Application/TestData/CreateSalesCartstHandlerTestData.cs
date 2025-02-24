using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Bogus;


namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSalesCartsHandlerTestData
{
    private static Guid Id = Guid.NewGuid();

    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated SalesCarts will have valid:
    /// - Productname (using internet Productnames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<CreateSalesCartsCommand> createSalesCartsHandlerFaker = new Faker<CreateSalesCartsCommand>()
        .RuleFor(u => u.SalesNumber, f => SalesCartsTestData.GenerateSalesNumber())
        .RuleFor(u => u.UserId, f => CartsTestData.GenerateUserId().ToString())
        .RuleFor(u => u.BranchId, f => CartsTestData.GenerateBranchId())
        .RuleFor(u => u.CartId, f => CartsTestData.GetId())
        .RuleFor(u => u.Products, f => new List<CartItem>
            {
                new CartItem(Guid.NewGuid(), Guid.NewGuid() , 4, false),
                new CartItem(Guid.NewGuid(), Guid.NewGuid() , 10, false),
                new CartItem(Guid.NewGuid(), Guid.NewGuid() , 20, false),
                new CartItem(Guid.NewGuid(), Guid.NewGuid() , 30, false)
            });

    public static Guid GetId()
    {
        return Id;
    }

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated Product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static CreateSalesCartsCommand GenerateValidCommand()
    {
        return createSalesCartsHandlerFaker.Generate();
    }
}
