using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProducts;

/// <summary>
/// Response model for GetProducts operation
/// </summary>
public class GetListProductResult
{
    /// <summary>
    /// Gets list from product
    /// </summary>
    public List<Product> Products { get; set; }

    public GetListProductResult(List<Product>? listProduct)
    {
        Products = listProduct;
    }

}
