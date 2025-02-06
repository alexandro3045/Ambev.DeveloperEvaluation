using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;

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
        CreateMap<CreateSalesCartsRequest, CreateSalesCartsCommand>();
        CreateMap<Domain.Entities.SalesCarts, CreateSalesCartsResult>();
        CreateMap<CreateSalesCartsResult, CreateSalesCartsResponse>();


    }
}
