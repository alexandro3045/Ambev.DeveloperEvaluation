
using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateSalesCarts;

/// <summary>
/// API response model for CreateSalesCarts operation
/// </summary>
public class CreateSalesCartsResponse 
{
    /// <summary>
    /// Gets the sale number when the carts was created.
    /// </summary>
    public int SalesNumber { get; set; }

    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the Customer when the carts was created.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets the total sales when the carts was created.
    /// </summary>
    public decimal TotalSalesAmount { get; set; }

    /// <summary>
    /// Gets the branch idsales when the carts was created.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets the List from product.
    /// </summary>
    public required List<ItemProductResult> Products { get; set; }

    /// <summary>
    /// Gets the quantities products when the carts was created.
    /// </summary>
    public int Quantities { get; set; }

    /// <summary>
    /// Gets the canceled item products when the carts was created.
    /// </summary>
    public bool Canceled { get; set; }

}
