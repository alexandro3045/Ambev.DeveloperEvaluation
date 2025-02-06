namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Request model for deleting a SalesCarts
/// </summary>
public class DeleteSalesCartsRequest
{
    /// <summary>
    /// The unique identifier of the SalesCarts to delete
    /// </summary>
    public Guid Id { get; set; }
}
