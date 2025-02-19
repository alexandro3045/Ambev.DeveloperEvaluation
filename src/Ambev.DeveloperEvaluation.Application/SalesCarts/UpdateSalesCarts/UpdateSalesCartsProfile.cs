using AutoMapper;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Profile for mapping between Carts entity and UpdateSalesCartsResponse
/// </summary>
public class UpdateSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSalesCarts operation
    /// </summary>
    public UpdateSalesCartsProfile()
    {
        CreateMap<UpdateSalesCartsCommand, CreateSalesCartsResult>();

        CreateMap<UpdateSalesCartsCommand, Domain.Entities.SalesCarts>()
         .ForMember(dest => dest.Carts, opt => opt.MapFrom(src =>
         new Domain.Entities.Carts
         {
             UserId = src.UserId,
             CreatedAt = src.CreatedAt,
             CartsProductsItemns = src.Products.Select(cp =>
             new CartsProductsItems { ProductId = cp.ProductId, Quantity = cp.Quantity }).ToList()
         }));

        CreateMap<Domain.Entities.SalesCarts, UpdateSalesCartsResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Carts.CartsProductsItemns.Select(cp =>
               new CartItemResult(cp.CartId, cp.ProductId, cp.Quantity, cp.TotalAmountItem, cp.UnitPrice))));
    }
}
