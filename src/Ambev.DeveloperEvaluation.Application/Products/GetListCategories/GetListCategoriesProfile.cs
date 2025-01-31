using Ambev.DeveloperEvaluation.Application.Products.GetListCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetCategories;

/// <summary>
/// Profile for mapping between Categories entity and GetCategoriesResult
/// </summary>
public class GetListCategoriesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListCategories operation
    /// </summary>
    public GetListCategoriesProfile()
    {
        CreateMap<string[], GetListCategoriesResult>()
        .ConstructUsing(categories => new GetListCategoriesResult(categories));
    }
}
