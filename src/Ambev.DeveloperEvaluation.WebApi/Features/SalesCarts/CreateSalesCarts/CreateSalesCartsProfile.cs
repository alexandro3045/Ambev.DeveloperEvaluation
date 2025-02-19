using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Branch.CreateBranchRequest;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

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
        CreateMap<CreateBranchRequest, Domain.Entities.Branch>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<ItemProduct, Product>();

        CreateMap<CreateSalesCartsRequest, CreateSalesCartsCommand>()
         .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Carts.Products))
         .ForMember(dest => dest.UserId, act => act.MapFrom(src => src.Carts.UserId));

        CreateMap<Domain.Entities.Carts, CreateSalesCartsResult>();
        
        CreateMap<CreateSalesCartsResult, CreateSalesCartsResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(cp =>
               new ItemProductResult( cp.ProductId, cp.Quantity, cp.TotalAmountItem, cp.UnitPrice))));
        ;

    }
}
