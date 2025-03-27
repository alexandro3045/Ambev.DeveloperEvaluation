using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.SalesCartsRequests;
using Ambev.DeveloperEvaluation.WebApi.SalesCarts.GetSalesCarts;
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

        CreateMap<GetListSalesCartsResult, GetListSalesCartsResponse>()
            .ForMember(dest => dest.ListSalesCarts, opt =>

                 opt.MapFrom(src => src.ListSalesCarts.Select(c =>
                             new GetSalesCartsResponse {
                                 SalesNumber = c.SalesNumber.Value,
                                 TotalSalesAmount = c.TotalSalesAmount,
                                 BranchId = c.BranchId,
                                 Products = c.Carts.CartsProductsItems.Select(p => new ItemProductResult(p.ProductId, p.Quantity, p.Quantity, p.Quantity, p.Canceled)).ToList(),
                                 Quantities = c.Quantities,
                                 Canceled = c.Canceled,
                                 UserId = c.UserId.ToString()
                             })));
    }
}
