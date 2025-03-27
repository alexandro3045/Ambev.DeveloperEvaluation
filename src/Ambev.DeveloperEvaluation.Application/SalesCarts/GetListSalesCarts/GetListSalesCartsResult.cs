namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;

/// <summary>
/// Response model for GetListSalesCarts operation
/// </summary>
public class GetListSalesCartsResult
{
    /// <summary>
    /// Gets list from carts
    /// </summary>
    public List<Domain.Entities.SalesCarts> ListSalesCarts { get; set; }

    public GetListSalesCartsResult(List<Domain.Entities.SalesCarts>? lisSalestCarts)
    {
        ListSalesCarts = lisSalestCarts;
    }
}
