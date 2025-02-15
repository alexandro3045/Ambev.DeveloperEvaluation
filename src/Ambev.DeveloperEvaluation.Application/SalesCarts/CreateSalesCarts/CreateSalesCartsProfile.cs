using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CreateSalesCarts.CreateSalesCarts;

/// <summary>
/// Profile for mapping between Carts entity and CreateSalesCartsResponse
/// </summary>
public class CreateSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSalesCarts operation
    /// </summary>
    public CreateSalesCartsProfile()
    {
        CreateMap<CreateSalesCartsCommand, Domain.Entities.Carts>();
        CreateMap<Domain.Entities.Carts, CreateSalesCartsResult>();
        CreateMap<Domain.Entities.Carts, CreateSalesCartsResult>();
    }
}
