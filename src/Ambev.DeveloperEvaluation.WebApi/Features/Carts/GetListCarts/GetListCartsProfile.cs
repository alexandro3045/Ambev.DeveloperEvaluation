using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetListCarts;
using Ambev.DeveloperEvaluation.Application.Products.GetListCategories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Cats.DeleteCarts.GetListCart;

/// <summary>
/// Profile for mapping GetListCarts feature requests to commands
/// </summary>
public class GetListCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListCarts feature
    /// </summary>
    public GetListCartProfile()
    {
        CreateMap<GetListCartsRequest, GetListCartsCommand>()
            .ConstructUsing(request => new GetListCartsCommand(request.Page, request.Size, request.Order,
              request.Direction, request.ColumnFilters));

        CreateMap<GetListCartsResult, GetListCartsResponse>()
            .ForMember(dest => dest.ListCarts, static opt => opt.MapFrom(static src => src.ListCarts.Select(p => new CartsResponse { Id = p.Id, UserId = p.UserId, CreatedAt = p.CreatedAt, Products = p.CartsProductsItemns.Select(i => new ItemProduct(i.ProductId, i.Quantity)).ToList() })));

        CreateMap<List<CartsProductsItems>, List<ItemProduct>>()
            .ConvertUsing(src => src.Select(c => new ItemProduct(c.ProductId, c.Quantity)).ToList());
    }
}
