using Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Extensions;
using Bogus;


namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateProductHandlerTestData
{
    private static Guid Id = Guid.NewGuid();

    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated Products will have valid:
    /// - Productname (using internet Productnames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<CreateProductsCommand> createProductHandlerFaker = new Faker<CreateProductsCommand>()
        .RuleFor(u => u.Id, f => GetId())
        .RuleFor(u => u.Price, f => new Faker().Random.Decimal(0.00m, 99.00m,2))
        .RuleFor(u => u.Category, f => new Faker().Internet.DomainName())
        .RuleFor(u => u.Description, f => new Faker().Finance.AccountName())
        .RuleFor(u => u.Image, f => new Faker().Image.ToString())
        .RuleFor(u => u.Title, f => new Faker().Commerce.ProductName())
        .RuleFor(u => u.Rating, f => new Rating { Count = new Faker().Random.Int(10), Rate = new Faker().Random.Decimal(0.00m, 99.00m, 2) });

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
    public static CreateProductsCommand GenerateValidCommand()
    {
        return createProductHandlerFaker.Generate();
    }


}
