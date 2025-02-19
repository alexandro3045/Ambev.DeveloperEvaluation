using Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Represents the response returned after successfully creating a new Carts.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly update Carts,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateSalesCartsResult : GetSalesCartsResult 
{
    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
