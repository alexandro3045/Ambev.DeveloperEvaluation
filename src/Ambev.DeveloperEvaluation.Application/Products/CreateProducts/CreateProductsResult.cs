﻿using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Application.Products.CreateProducts;

/// <summary>
/// Represents the response returned after successfully creating a new Products.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Products,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateProductsResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created Products.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created Products in the system.</value>
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
    public string Descripption { get; set; }

    /// <summary>
    /// Gets the category from product.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets the image from product.
    /// </summary>
    public string Image { get; set; }


    public Rating Rating { get; set; }
}
