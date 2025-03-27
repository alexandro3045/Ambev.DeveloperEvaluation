
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.WebApi.SalesCarts.GetSalesCarts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;

/// <summary>
/// API response model for ListSalesCartsOperation
/// </summary>
public class GetListSalesCartsResponse
{
    /// <summary>
    /// The list Carts
    /// </summary>
    public List<GetSalesCartsResponse> ListSalesCarts { get; set; }
}
