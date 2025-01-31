using Ambev.DeveloperEvaluation.Application.Products.GetListProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;

/// <summary>
/// Profile for mapping GetListProducts feature requests to commands
/// </summary>
public class GetListProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListProducts feature
    /// </summary>
    public GetListProductProfile()
    {
        CreateMap<GetListProductRequest, GetListProductCommand>()
            .ConstructUsing(request => new GetListProductCommand(request.Page, request.Size, request.Order, request.Direction));

        CreateMap<GetListProductRequest, GetListProductByCategoryCommand>()
          .ConstructUsing(request => new GetListProductByCategoryCommand(request.Page, request.Size, request.Order, request.Direction, request.Category));

        CreateMap<GetListProductResult, GetListProductResponse>();
    }
}
