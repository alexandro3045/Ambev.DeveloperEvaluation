
namespace Ambev.DeveloperEvaluation.Application.Products.GetListCategories;

/// <summary>
/// Response model for GetCategories products
/// </summary>
public class GetListCategoriesResult
{
    /// <summary>
    /// Gets list from categories from product
    /// </summary>
    public string[] Categories { get; set; } = [];

    public GetListCategoriesResult(string[] categories)
    {
        if (categories.Length == 0) return;
        Categories = new string[categories.Length];
        for(int i = 0; i < categories.Length; i++)
        {
            Categories[i] = categories[i];
        }
    }
}
