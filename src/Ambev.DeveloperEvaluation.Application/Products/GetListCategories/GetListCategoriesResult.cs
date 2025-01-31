using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProducts;

/// <summary>
/// Response model for GetCategories products
/// </summary>
public class GetListCategoriesResult
{
    /// <summary>
    /// Gets list from categories from product
    /// </summary>
    public string[] Categories { get; set; }

    
}
