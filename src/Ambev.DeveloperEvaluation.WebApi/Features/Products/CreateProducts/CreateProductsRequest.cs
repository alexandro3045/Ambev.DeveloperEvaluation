using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

/// <summary>
/// Represents a request to create a new products in the system.
/// </summary>
public class CreateProductsRequest
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
    public required string Descripption { get; set; }

    /// <summary>
    /// Gets the category from product.
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// Gets the image from product.
    /// </summary>
    public required byte[] Image { get; set; }

    /// <summary>
    /// Gets the rating from rating.
    /// </summary>
    public required Rating Rating { get; set; }
}