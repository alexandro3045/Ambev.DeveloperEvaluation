using Ambev.DeveloperEvaluation.Application.Products.GetProducts;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProducts;

/// <summary>
/// Represents the response returned after successfully creating a new Products.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly update Products,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateProductsResult : GetProductsResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created Products.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created Products in the system.</value>
    public Guid Id { get; set; }
}
