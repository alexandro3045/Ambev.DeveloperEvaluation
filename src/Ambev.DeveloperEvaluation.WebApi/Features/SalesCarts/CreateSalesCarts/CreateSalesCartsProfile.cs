using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Branch.CreateBranchRequest;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

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
        
        CreateMap<CreateSalesCartsResult, CreateSalesCartsResponse>();

    }
}
