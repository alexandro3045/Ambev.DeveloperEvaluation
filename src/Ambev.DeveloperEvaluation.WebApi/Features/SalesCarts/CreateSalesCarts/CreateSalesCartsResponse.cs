
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateSalesCarts;

/// <summary>
/// API response model for CreateSalesCarts operation
/// </summary>
public class CreateSalesCartsResponse : CreateSalesCartsRequest
{
    
    /// <summary>
    /// The unique identifier of the created SalesCarts
    /// </summary>
    public Guid Id { get; set; }
    
}
