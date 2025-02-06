using Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Cats.DeleteSalesCarts.GetListSalesCart;

/// <summary>
/// Profile for mapping GetListSalesCarts feature requests to commands
/// </summary>
public class GetListSalesCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListSalesCarts feature
    /// </summary>
    public GetListSalesCartProfile()
    {
        CreateMap<GetListSalesCartsRequest, GetListSalesCartsCommand>()
            .ConstructUsing(request => new GetListSalesCartsCommand(request.Page, request.Size, request.Order,
              request.Direction, request.ColumnFilters));

         CreateMap<GetListSalesCartsResult, GetListSalesCartsResponse>();
    }
}
