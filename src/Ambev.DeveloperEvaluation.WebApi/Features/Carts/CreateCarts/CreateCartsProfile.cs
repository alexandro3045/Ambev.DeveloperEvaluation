using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCarts;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCarts feature
    /// </summary>
    public CreateCartsProfile()
    {
        CreateMap<ItemProduct, CartItem>();

        CreateMap<CartsRequest, CreateCartsCommand>()
            .ForMember(dest => dest.CreatedAt, static opt => opt.MapFrom(static src => src.Date != default ? src.Date : DateTime.Now));

        CreateMap<Domain.Entities.ProductsItems, ItemProduct>()
            .ForMember(dest => dest.ProductId, static opt => opt.MapFrom(static src => src.ProductId))
            .ForMember(dest => dest.Quantity, static opt => opt.MapFrom(static src => src.Quantity));

        CreateMap<CreateCartsResult, CartsResponse>()
            .ForMember(dest => dest.Products, static opt => opt.MapFrom(static src => src.Products));           

        CreateMap<CartsRequest, CreateCartsCommand>()
            .ForMember(dest => dest.CreatedAt, static opt => opt.MapFrom(static src => src.Date != default ? src.Date : DateTime.Now));

        CreateMap<Domain.Entities.Carts, CreateCartsResult>();

    }
}
