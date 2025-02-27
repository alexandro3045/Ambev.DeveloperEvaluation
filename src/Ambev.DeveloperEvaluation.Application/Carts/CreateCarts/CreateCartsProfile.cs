using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Carts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

/// <summary>
/// Profile for mapping between Carts entity and CreateCartsResponse
/// </summary>
public class CreateCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCarts operation
    /// </summary>
    public CreateCartsProfile()
    {
        CreateMap<Domain.Entities.Carts, BaseNotification>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().Name))
           .ForMember(dest => dest.Action, opt => opt.MapFrom(src => ActionNotification.Created));

        CreateMap<CartsProductsItems, ProductsItems>();

        CreateMap<CreateCartsCommand, Domain.Entities.Carts>()
           .ForMember(dest => dest.CartsProductsItems, opt => opt.MapFrom(src => src.Products.Select(p => new CartsProductsItems { ProductId = p.ProductId, Quantity = p.Quantity })));

        CreateMap<Domain.Entities.Carts, CreateCartsResult>()
          .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt))
          .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.CartsProductsItems.Select(p => new CartsProductsItems { ProductId = p.ProductId, Quantity = p.Quantity })));
    }
}
