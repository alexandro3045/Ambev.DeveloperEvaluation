using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Branch.CreateBranchRequest;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateCards;

/// <summary>
/// Profile for mapping between Application and API UpdateSalesCartsResponse
/// </summary>
public class UpdateSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCards feature
    /// </summary>
    public UpdateSalesCartsProfile()
    {
        CreateMap<CreateBranchRequest, Domain.Entities.Branch>();

        CreateMap<ItemProduct, Product>();

        CreateMap<UpdateSalesCartsRequest, UpdateSalesCartsCommand>()
         .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Carts.Products.Select(cp =>
               new CartItem(cp.ProductId, cp.Quantity, cp.Canceled))))
         .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => src.Date))
         .ForMember(dest => dest.CartId, act => act.MapFrom(src => src.Carts.Id));

        CreateMap<Domain.Entities.Carts, UpdateSalesCartsResult>();

        CreateMap<UpdateSalesCartsResult, UpdateSalesCartsResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(cp =>
               new ItemProductResult(cp.ProductId, cp.Quantity, cp.TotalAmountItem, cp.UnitPrice, cp.Canceled, cp.Discounts))));
    }
}

