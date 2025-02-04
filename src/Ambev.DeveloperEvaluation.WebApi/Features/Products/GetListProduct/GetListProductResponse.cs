
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;

/// <summary>
/// API response model for ListProductsoperation
/// </summary>
public class GetListProductResponse
{
    /// <summary>
    /// The list product
    /// </summary>
    public List<Product> ListProduct { get; set; }
}
