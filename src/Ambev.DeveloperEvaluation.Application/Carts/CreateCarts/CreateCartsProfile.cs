using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

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
        CreateMap<CartsProductItem, ProductsItems>();

        CreateMap<CreateCartsCommand, Domain.Entities.Carts>()
           .ForMember(dest => dest.CartsProductsItemns, static opt => opt.MapFrom(static src => src.Products.Select(p => new CartsProductItem { ProductId = p.ProductId, Quantity = p.Quantity })));

        CreateMap<Domain.Entities.Carts, CreateCartsResult>()
          .ForMember(dest => dest.Date, static opt => opt.MapFrom(static src => src.CreatedAt))
          .ForMember(dest => dest.Products, static opt => opt.MapFrom(static src => src.CartsProductsItemns.Select(p => new ProductsItems { ProductId = p.ProductId, Quantity = p.Quantity  }))); ;
    }
}
