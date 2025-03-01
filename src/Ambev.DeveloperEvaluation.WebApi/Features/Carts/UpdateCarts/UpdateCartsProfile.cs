using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCards;

/// <summary>
/// Profile for mapping between Application and API UpdateCartsResponse
/// </summary>
public class UpdateCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCards feature
    /// </summary>
    public UpdateCartsProfile()
    {
        CreateMap<UpdateCartsRequest, UpdateCartsCommand>()
           .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(p => new CartItem(src.Id, p.ProductId, p.Quantity, p.Canceled))))
           .ForMember(dest => dest.CreatedAt, static opt => opt.MapFrom(static src => src.Date != default ? src.Date : DateTime.Now));


        CreateMap<UpdateCartsResult, UpdateCartsResponse>()
          .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(p => new ItemProduct(p.ProductId, p.Quantity))));
    }
}

