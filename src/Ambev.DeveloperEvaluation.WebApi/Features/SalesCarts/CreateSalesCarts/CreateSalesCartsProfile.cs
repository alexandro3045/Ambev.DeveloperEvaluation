using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Branch.CreateBranchRequest;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateSalesCarts;

/// <summary>
/// Profile for mapping between Application and API CreateSalesCarts responses
/// </summary>
public class CreateSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSalesCarts feature
    /// </summary>
    public CreateSalesCartsProfile()
    {

        CreateMap<CreateBranchRequest, Domain.Entities.Branch>();

        CreateMap<CreateSalesCartsRequest, CreateSalesCartsCommand>()
         .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Carts.Products.Select(cp =>
               new CartItem(cp.ProductId, cp.Quantity, false))))
         .ForMember(dest => dest.UserId, act => act.MapFrom(src => src.Carts.UserId))
         .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => src.Carts.Date));

        CreateMap<Domain.Entities.Carts, CreateSalesCartsResult>();

        CreateMap<CreateSalesCartsResult, CreateSalesCartsResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(cp =>
               new ItemProductResult(cp.ProductId, cp.Quantity, cp.TotalAmountItem, cp.UnitPrice, cp.Canceled, cp.Discounts))));
        ;

    }
}
