using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CreateSalesCarts.CreateSalesCarts;

/// <summary>
/// Profile for mapping between Carts entity and CreateSalesCartsResponse
/// </summary>
public class CreateSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSalesCarts operation
    /// </summary>
    public CreateSalesCartsProfile()
    {
        CreateMap<CreateSalesCartsCommand, Domain.Entities.SalesCarts>()
             .ForMember(dest => dest.Carts, opt => opt.MapFrom(src =>
             new Domain.Entities.Carts { UserId = src.UserId, CreatedAt = src.CreatedAt,
                 CartsProductsItems = src.Products.Select(cp =>
                 new CartsProductsItems { ProductId = cp.ProductId, Quantity = cp.Quantity }).ToList()}));

        CreateMap<Domain.Entities.SalesCarts, CreateSalesCartsResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Carts.CartsProductsItems.Select(cp =>
               new CartItemResult(cp.CartId, cp.ProductId,cp.Quantity,cp.TotalAmountItem, cp.UnitPrice,cp.Discounts,cp.Canceled ))));

    }
}


