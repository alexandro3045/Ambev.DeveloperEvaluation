using Ambev.DeveloperEvaluation.Application.Categoriess.GetListCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categoriess.GetListCategories;

/// <summary>
/// Profile for mapping GetListCategories feature requests to commands
/// </summary>
public class GetListCAtegoriesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListCategories feature
    /// </summary>
    public GetListCategorieProfile()
    {
        CreateMap<GetListCategoriesRequest, GetListCategoriesCommand>()
            .ConstructUsing(request => new GetListCategoriesCommand(request.Page, request.Size, request.Order, request.Direction));

        CreateMap<GetListCategoriesResult, GetListCategoriesResponse>();
    }
}
