
namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.SalesCartsRequests;

/// <summary>
/// API response model for CreateSalesCarts/UpdateSalesCarts operation
/// </summary>
public class SalesCartsResponse : SalesCartsRequest
{
    public Guid Id { get; init; }
}
