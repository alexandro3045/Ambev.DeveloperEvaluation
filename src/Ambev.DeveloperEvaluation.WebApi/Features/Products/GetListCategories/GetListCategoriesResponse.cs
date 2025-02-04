
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListCategories;

/// <summary>
/// API response model for ListCategoriesoperation
/// </summary>
public class GetListCategoriesResponse
{
    /// <summary>
    /// The list categories
    /// </summary>
    public string[] ListCategories { get; set; }
}
