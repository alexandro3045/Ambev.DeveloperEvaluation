using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

/// <summary>
/// Represents a request to create a new products in the system.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Gets the Title from product
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Gets the price from product
    /// </summary>
    public required decimal Price { get; set; }

    /// <summary>
    /// Gets the description from product.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Gets the category from product.
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// Gets the image from product.
    /// </summary>
    public required string Image { get; set; }

    /// <summary>
    /// Gets the rating from product.
    /// </summary>
    public required Rating Rating { get; set; }
}