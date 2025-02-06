using Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.SalesCarts.GetSalesCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetSalesCarts;

/// <summary>
/// Profile for mapping GetSalesCarts feature requests to commands
/// </summary>
public class GetSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSalesCarts feature
    /// </summary>
    public GetSalesCartsProfile()
    {
        CreateMap<Guid, GetSalesCartsCommand>()
            .ConstructUsing(id => new GetSalesCartsCommand(id));

        CreateMap<Domain.Entities.Carts, GetSalesCartsResult>();

        CreateMap<GetSalesCartsResult, GetSalesCartsResponse>();
    }
}
