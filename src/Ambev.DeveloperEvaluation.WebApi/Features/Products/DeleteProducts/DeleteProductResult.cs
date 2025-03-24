

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;

/// <summary>
/// API response model for DeleteProductResult operation
/// </summary>
public class DeleteProductResult {

    /// <summary>
    /// Indicates whether the deletion was successful
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Messages whether the deletion was successful
    /// </summary>
    public string Message { get; set; }
}
