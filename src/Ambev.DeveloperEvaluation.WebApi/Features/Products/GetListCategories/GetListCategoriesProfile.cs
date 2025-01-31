using Ambev.DeveloperEvaluation.Application.Products.GetListCategorias;
using Ambev.DeveloperEvaluation.Application.Products.GetListCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categoriess.GetListCategories;

/// <summary>
/// Profile for mapping GetListCategories feature requests to commands
/// </summary>
public class GetListCategoriesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListCategories feature
    /// </summary>
    public GetListCategoriesProfile()
    {
        CreateMap<GetListCategoriesRequest, GetListCategoriesCommand>()
            .ConstructUsing(request => new GetListCategoriesCommand(request.Page, request.Size, request.Order, request.Direction));

        CreateMap<GetListCategoriesResult, GetListCategoriesResponse>();
    }
}
