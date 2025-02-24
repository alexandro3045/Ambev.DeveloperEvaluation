
using Ambev.DeveloperEvaluation.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// API response model for GetProducts operation
/// </summary>
public class GetProductsResponse
{

    /// <summary>
    /// Gets the id from product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the Title from product
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets the price from product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the description from product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets the category from product.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets the image from product.
    /// </summary>
    public string Image { get; set; }

    [Column(TypeName = "jsonb")]
    public Rating Rating { get; set; }
}
