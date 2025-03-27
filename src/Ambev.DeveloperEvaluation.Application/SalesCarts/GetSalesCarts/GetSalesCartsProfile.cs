using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;

/// <summary>
/// Profile for mapping between Carts entity and GetSalesCartsResponse
/// </summary>
public class GetSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSalesCarts operation
    /// </summary>
    public GetSalesCartsProfile()
    {
        CreateMap<Domain.Entities.SalesCarts, GetSalesCartsResult>()
          .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Carts.CartsProductsItems.Select(p => new CartItemResult(p.ProductId,p.ProductId, p.Quantity,p.TotalAmountItem, p.UnitPrice,p.Discounts,p.Canceled))));
    }
}
