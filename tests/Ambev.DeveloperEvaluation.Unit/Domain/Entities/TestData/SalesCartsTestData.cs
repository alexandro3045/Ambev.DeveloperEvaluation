using Bogus;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SalesCartsTestData
{
   /// <summary>
    /// Configures the Faker to generate valid SalesCarts entities.
    /// The generated SalesCartss will have valid:
    /// - SalesCartsname (using internet SalesCartsnames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<DeveloperEvaluation.Domain.Entities.SalesCarts> SalesCartsFaker = new Faker<DeveloperEvaluation.Domain.Entities.SalesCarts>()
        .RuleFor(u => u.Carts, f => CartsTestData.GenerateValidCarts())
        .RuleFor(u => u.CreatedAt, f => DateTime.Now)
        .RuleFor(u => u.UserId, f => CartsTestData.GenerateUserId())
        .RuleFor(u => u.BranchId, f => CartsTestData.GenerateBranchId())
        .RuleFor(u => u.SalesNumber, f => GenerateSalesNumber())
        .RuleFor(u => u.CartId, f => CartsTestData.GetId());

    /// <summary>
    /// Generates a valid SalesCarts entity with randomized data.
    /// The generated SalesCarts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SalesCarts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.SalesCarts GenerateValidSalesCarts()
    {
        return SalesCartsFaker.Generate();
    }

    /// <summary>
    /// Generates a valid SalesCarts entity with randomized data.
    /// The generated SalesCarts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid SalesCarts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.SalesCarts GenerateInValidProductsSalesCarts()
    {
        var SalesCarts = GenerateValidSalesCarts();

        SalesCarts.Carts.CartsProductsItems.Clear();

        return SalesCarts;
    }

    /// <summary>
    /// Generates a valid SalesCarts entity with randomized data.
    /// The generated SalesCarts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid SalesCarts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.SalesCarts GenerateInValidUserIdSalesCarts()
    {
        var SalesCarts = GenerateValidSalesCarts();

        SalesCarts.UserId = Guid.Empty;

        return SalesCarts;
    }

    /// <summary>
    /// Generates a valid SalesCarts entity with randomized data.
    /// The generated SalesCarts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid SalesCarts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.SalesCarts GenerateInValidBranchIdSalesCarts()
    {
        var SalesCarts = GenerateValidSalesCarts();

        SalesCarts.BranchId = Guid.Empty;

        return SalesCarts;
    }

    /// <summary>
    /// Generates a valid SalesCarts entity with randomized data.
    /// The generated SalesCarts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid SalesCarts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.SalesCarts GenerateInValidSalesNumberSalesCarts()
    {
        var SalesCarts = GenerateValidSalesCarts();

        SalesCarts.SalesNumber = null;

        return SalesCarts;
    }

    /// <summary>
    /// Generates a valid SalesCarts entity with randomized data.
    /// The generated SalesCarts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid SalesCarts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.SalesCarts GenerateInValidCartsSalesCarts()
    {
        var SalesCarts = GenerateValidSalesCarts();

        SalesCarts.Carts = new DeveloperEvaluation.Domain.Entities.Carts();

        return SalesCarts;
    }

    /// <summary>
    /// Generates a username that exceeds the maximum length limit.
    /// The generated username will:
    /// - Contain random guid
    /// This is useful for testing username length validation error cases.
    /// </summary>
    /// <returns>A username that exceeds the maximum length limit.</returns>
    public static int GenerateSalesNumber()
    {
        return new Faker().Random.Int(1,9999);
    }
}
