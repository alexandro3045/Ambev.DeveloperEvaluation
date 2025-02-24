namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;

/// <summary>
/// Response model for GetListSalesCarts operation
/// </summary>
public class GetListSalesCartsResult
{
    /// <summary>
    /// Gets list from carts
    /// </summary>
    public List<Domain.Entities.Carts> ListSalesCarts { get; set; }

    public GetListSalesCartsResult(List<Domain.Entities.Carts>? lisSalestCarts)
    {
        ListSalesCarts = lisSalestCarts;
    }
}
