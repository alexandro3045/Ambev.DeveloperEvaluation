
namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetSalesCarts;

/// <summary>
/// Request model for getting a SalesCarts by ID
/// </summary>
public class GetSalesCartsRequest
{
    /// <summary>
    /// The unique identifier of the salescarts to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
