namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;

/// <summary>
/// Request model for getting a SalesCarts by Page, size, Order, Direction, filters and search term
/// </summary>
public class GetListSalesCartsRequest
{
    /// <summary>
    /// The page SalesCarts list to retrieve
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// The size SalesCarts list to retrieve
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The order SalesCarts list to retrieve
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// The direction SalesCarts list to retrieve
    /// </summary>
    public string? Direction { get; set; }

    /// <summary>
    /// The filter SalesCarts list to retrieve
    /// </summary>
    public string? ColumnFilters { get; set; }
}
