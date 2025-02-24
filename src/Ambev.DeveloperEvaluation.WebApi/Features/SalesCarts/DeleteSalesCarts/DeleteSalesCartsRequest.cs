namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Request model for deleting a Carts
/// </summary>
public class DeleteSalesCartsRequest
{
    /// <summary>
    /// The unique identifier of the Carts to delete
    /// </summary>
    public Guid Id { get; set; }
}
