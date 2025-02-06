using Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;
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
        CreateMap<UpdateSalesCartsRequest, UpdateSalesCartsCommand>();
        CreateMap<UpdateSalesCartsResult, UpdateSalesCartsResponse>();
    }
}

