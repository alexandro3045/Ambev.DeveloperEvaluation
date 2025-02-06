using Ambev.DeveloperEvaluation.Application.SalesCarts.DeleteSalesCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Profile for mapping DeleteSalesCarts feature requests to commands
/// </summary>
public class DeleteSalesCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSalesCarts feature
    /// </summary>
    public DeleteSalesCartsProfile()
    {
        CreateMap<Guid, DeleteSalesCartsCommand>()
            .ConstructUsing(id => new DeleteSalesCartsCommand(id));
    }
}
