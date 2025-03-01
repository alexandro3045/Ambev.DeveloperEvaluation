
namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

/// <summary>
/// API response model for Createproducts operation
/// </summary>
public class CreateProductsResponse : CreateProductRequest
{
    /// <summary>
    /// The unique identifier of the created product
    /// </summary>
    public Guid Id { get; set; }

}
