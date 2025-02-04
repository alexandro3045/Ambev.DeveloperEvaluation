using Ambev.DeveloperEvaluation.Application.Carts.GetListCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Cats.DeleteCarts.GetListCart;

/// <summary>
/// Profile for mapping GetListCarts feature requests to commands
/// </summary>
public class GetListCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListCarts feature
    /// </summary>
    public GetListCartProfile()
    {
        CreateMap<GetListCartsRequest, GetListCartsCommand>()
            .ConstructUsing(request => new GetListCartsCommand(request.Page, request.Size, request.Order,
              request.Direction, request.ColumnFilters));

         CreateMap<GetListCartsResult, GetListCartsResponse>();
    }
}
