using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;

/// <summary>
/// Profile for mapping GetCarts feature requests to commands
/// </summary>
public class GetCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCarts feature
    /// </summary>
    public GetCartsProfile()
    {
        CreateMap<Guid, GetCartsCommand>()
            .ConstructUsing(id => new GetCartsCommand(id));

        CreateMap<Domain.Entities.Carts, GetCartsResult>();

        CreateMap<GetCartsResult, CartsResponse>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.CartsProductsItemns.Select(p => new ItemProduct( p.ProductId, p.Quantity)))); ; ;
    }
}
