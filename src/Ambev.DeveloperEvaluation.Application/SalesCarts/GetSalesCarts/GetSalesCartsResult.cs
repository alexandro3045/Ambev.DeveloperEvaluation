using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;

/// <summary>
/// Response model for GetSalesCarts operation
/// </summary>
public class GetSalesCartsResult
{
    /// <summary>
    /// Gets the sale number when the carts was created.
    /// </summary>
    public int SalesNumber { get; set; }

    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the Customer when the carts was created.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets the Customer when the carts was created.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets the total sales when the carts was created.
    /// </summary>
    public decimal TotalSalesAmount { get; set; }

    /// <summary>
    /// Gets the branch idsales when the carts was created.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets the branch sales when the carts was created.
    /// </summary>
    public Branch Branch { get; set; }

    /// <summary>
    /// Gets the List from product.
    /// </summary>
    public List<CartItemResult> Products { get; set; }

    /// <summary>
    /// Gets the quantities products when the carts was created.
    /// </summary>
    public int Quantities { get; set; }

    /// <summary>
    /// Gets the canceled item products when the carts was created.
    /// </summary>
    public bool Canceled { get; set; }
}
