using Ambev.DeveloperEvaluation.Application.Products.GetProducts;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProducts;

/// <summary>
/// Represents the response returned after successfully creating a new ProductsItems.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly update ProductsItems,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateProductResult : GetProductsResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created ProductsItems.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created ProductsItems in the system.</value>
    public Guid Id { get; set; }
}
