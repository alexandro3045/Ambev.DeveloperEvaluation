using Bogus;
using System.Security.Principal;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CartsTestData
{
    private static Guid Id = Guid.NewGuid();    

    /// <summary>
    /// Configures the Faker to generate valid Carts entities.
    /// The generated Cartss will have valid:
    /// - Cartsname (using internet Cartsnames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<DeveloperEvaluation.Domain.Entities.Carts> CartsFaker = new Faker<DeveloperEvaluation.Domain.Entities.Carts>()
        .RuleFor(u => u.CartsProductsItems, f =>
            new List<DeveloperEvaluation.Domain.Entities.CartsProductsItems>
            {
                new DeveloperEvaluation.Domain.Entities.CartsProductsItems
                            { CartId = Guid.NewGuid(), Id = Guid.NewGuid(), Canceled = false, ProductId =  Guid.NewGuid(), Quantity = 1, UnitPrice = 100},
                        new DeveloperEvaluation.Domain.Entities.CartsProductsItems 
                            { CartId = Guid.NewGuid(), Id = Guid.NewGuid(), Canceled = false, ProductId =  Guid.NewGuid(), Quantity = 4, UnitPrice = 200},
                        new DeveloperEvaluation.Domain.Entities.CartsProductsItems
                            { CartId = Guid.NewGuid(), Id = Guid.NewGuid(), Canceled = false, ProductId =  Guid.NewGuid(), Quantity = 10, UnitPrice = 300},
                        new DeveloperEvaluation.Domain.Entities.CartsProductsItems
                            { CartId = Guid.NewGuid(), Id = Guid.NewGuid(), Canceled = false, ProductId =  Guid.NewGuid(), Quantity = 20, UnitPrice = 400},
                        new DeveloperEvaluation.Domain.Entities.CartsProductsItems
                            { CartId = Guid.NewGuid(), Id = Guid.NewGuid(), Canceled = false, ProductId =  Guid.NewGuid(), Quantity = 30, UnitPrice = 500},
            })
        .RuleFor(u => u.Id, f => GetId())
        .RuleFor(u => u.CreatedAt, f => DateTime.Now)
        .RuleFor(u => u.UserId, f => GenerateUserId().ToString());

    public static Guid GetId()
    {
        return Id;
    }

    /// <summary>
    /// Generates a valid Carts entity with randomized data.
    /// The generated Carts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Carts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.Carts GenerateValidCarts()
    {
        return CartsFaker.Generate();
    }

    /// <summary>
    /// Generates a valid Carts entity with randomized data.
    /// The generated Carts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid Carts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.Carts GenerateInValidProductsCarts()
    {
        var Carts = GenerateValidCarts();

        Carts.CartsProductsItems.Clear();
        
        return Carts;
    }

    /// <summary>
    /// Generates a valid Carts entity with randomized data.
    /// The generated Carts will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid Carts entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.Carts GenerateInValidUserIdCarts()
    {
        var Carts = GenerateValidCarts();

        Carts.UserId = string.Empty;

        return Carts;
    }

    /// <summary>
    /// Generates a username that exceeds the maximum length limit.
    /// The generated username will:
    /// - Contain random guid
    /// This is useful for testing username length validation error cases.
    /// </summary>
    /// <returns>A username that exceeds the maximum length limit.</returns>
    public static Guid GenerateUserId()
    {
        return new Faker().Random.Guid();
    }

    /// <summary>
    /// Generates a username that exceeds the maximum length limit.
    /// The generated username will:
    /// - Contain random guid
    /// This is useful for testing username length validation error cases.
    /// </summary>
    /// <returns>A username that exceeds the maximum length limit.</returns>
    public static Guid GenerateBranchId()
    {
        return new Faker().Random.Guid();
    }
}
