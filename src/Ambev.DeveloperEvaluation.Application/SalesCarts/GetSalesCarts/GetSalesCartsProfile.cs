using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;

/// <summary>
/// Profile for mapping between Carts entity and GetSalesCartsResponse
/// </summary>
public class GetSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSalesCarts operation
    /// </summary>
    public GetSalesCartsProfile()
    {
        CreateMap<Domain.Entities.SalesCarts, GetSalesCartsResult>();
    }
}
