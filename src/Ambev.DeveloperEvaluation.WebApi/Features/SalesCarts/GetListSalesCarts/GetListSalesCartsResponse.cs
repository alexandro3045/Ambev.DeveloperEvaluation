
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;

/// <summary>
/// API response model for ListSalesCartsOperation
/// </summary>
public class GetListSalesCartsResponse
{
    /// <summary>
    /// The list Carts
    /// </summary>
    public List<CartsResponse> ListSalesCarts { get; set; }
}
