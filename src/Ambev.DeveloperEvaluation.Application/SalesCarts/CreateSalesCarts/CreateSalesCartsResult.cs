using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;

/// <summary>
/// Represents the response returned after successfully creating a  Carts.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the ly create Carts,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSalesCartsResult
{

    public CreateSalesCartsResult(int salesNumber, DateTime createdAt, Guid userId, decimal totalSalesAmount, Guid branchId, List<CartItemResult> products, int quantities, bool canceled, Guid cartId)
    {
        SalesNumber = salesNumber;
        CreatedAt = createdAt;
        UserId = userId;
        TotalSalesAmount = totalSalesAmount;
        BranchId = branchId;
        Products = products;
        Quantities = quantities;
        Canceled = canceled;
        CartId = cartId;
    }

    public CreateSalesCartsResult(int salesNumber, DateTime createdAt, Guid userId, decimal totalSalesAmount, Guid branchId, List<CartItemResult> products)
    {
        SalesNumber = salesNumber;
        CreatedAt = createdAt;
        UserId = userId;
        TotalSalesAmount = totalSalesAmount;
        BranchId = branchId;
        Products = products;
    }

    /// <summary>
    /// Gets the CartId when the saleCarts was created.
    /// </summary>
    public Guid CartId { get; set; }

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
