using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Profile for mapping between Carts entity and UpdateCartsResponse
/// </summary>
public class UpdateCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCarts operation
    /// </summary>
    public UpdateCartsProfile()
    {
        CreateMap<CartItem, CartsProductsItems>();

        CreateMap<UpdateCartsCommand, Domain.Entities.Carts>()
            .ForMember(dest => dest.CartsProductsItems, opt => opt.MapFrom(src => src.Products.Select(p => new CartItem(p.CartId, p.ProductId, p.Quantity, p.Canceled))));

        CreateMap<UpdateCartsCommand, GetCartsResult>();

        CreateMap<Domain.Entities.Carts, UpdateCartsResult>()
          .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt))
          .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.CartsProductsItems.Select(p => new CartsProductsItems { ProductId = p.ProductId, Quantity = p.Quantity })));
    }
}
