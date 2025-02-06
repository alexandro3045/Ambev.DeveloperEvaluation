
namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;

/// <summary>
/// API response model for ListSalesCartsOperation
/// </summary>
public class GetListSalesCartsResponse
{
    /// <summary>
    /// The list SalesCarts
    /// </summary>
    public List<Domain.Entities.SalesCarts> ListSalesCarts { get; set; }
}
