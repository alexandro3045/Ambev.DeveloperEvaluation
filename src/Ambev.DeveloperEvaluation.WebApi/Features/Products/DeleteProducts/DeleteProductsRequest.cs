namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;

/// <summary>
/// Request model for deleting a product
/// </summary>
public class DeleteProductsRequest
{
    /// <summary>
    /// The unique identifier of the product to delete
    /// </summary>
    public Guid Id { get; set; }
}
