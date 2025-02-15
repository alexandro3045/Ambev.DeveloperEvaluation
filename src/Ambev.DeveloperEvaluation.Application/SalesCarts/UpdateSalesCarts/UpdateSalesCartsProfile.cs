using AutoMapper;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Profile for mapping between Carts entity and UpdateSalesCartsResponse
/// </summary>
public class UpdateSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSalesCarts operation
    /// </summary>
    public UpdateSalesCartsProfile()
    {
        CreateMap<UpdateSalesCartsCommand, Domain.Entities.Carts>();
        CreateMap<Domain.Entities.Carts, UpdateSalesCartsResult>();
        CreateMap<Domain.Entities.Carts, CreateSalesCartsResult>();
    }
}
