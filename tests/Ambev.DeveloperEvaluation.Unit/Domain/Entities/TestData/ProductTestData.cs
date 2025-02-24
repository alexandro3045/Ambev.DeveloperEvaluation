using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    private static Guid Id = Guid.NewGuid();

    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated Products will have valid:
    /// - Id 
    /// - CreatedAt 
    /// - Price 
    /// - Category 
    /// - Description 
    /// - Image 
    /// - Title 
    /// - Rating 
    /// </summary>
    private static readonly Faker<DeveloperEvaluation.Domain.Entities.Product> ProductFaker = new Faker<DeveloperEvaluation.Domain.Entities.Product>()
        .RuleFor(u => u.Id, f => GetId())
        .RuleFor(u => u.CreatedAt, f => DateTime.Now)
        .RuleFor(u => u.Price, f => new Faker().Random.Decimal(1,299))
        .RuleFor(u => u.Category, f => new Faker().Internet.DomainName())
        .RuleFor(u => u.Description, f => new Faker().Finance.AccountName())
        .RuleFor(u => u.Image, f => new Faker().Image.ToString())
        .RuleFor(u => u.Title, f => new Faker().Commerce.ProductName())
        .RuleFor(u => u.Rating, f => new Rating { Count = new Faker().Random.Int(), Rate = new Faker().Random.Decimal() } );

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
    public static DeveloperEvaluation.Domain.Entities.Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated Product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid Product entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.Product GenerateInValidProductsProduct()
    {
        var Product = GenerateValidProduct();
      
        return Product;
    }

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated Product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A invalidvalid Product entity with randomly generated data.</returns>
    public static DeveloperEvaluation.Domain.Entities.Product GenerateInValidProduct(string property, object? value = null)
    {
        var Product = GenerateValidProduct();
        PropertyInfo? propertyInfo = Product.GetType().GetProperty(property);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(Product, Convert.ChangeType(value, propertyInfo.PropertyType));
        }

        return Product;
    }
}
