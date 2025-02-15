using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;

/// <summary>
/// Profile for mapping between Carts entity and GetListSalesCartsResult
/// </summary>
public class GetListSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListSalesCarts operation
    /// </summary>
    public GetListSalesCartsProfile()
    {
        CreateMap<List<Domain.Entities.Carts>, GetListSalesCartsResult>()
            .ConstructUsing(listSalseCarts => new GetListSalesCartsResult(listSalseCarts)); 
    }
}
