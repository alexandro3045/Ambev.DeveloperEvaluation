namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.SalesCartsRequests;

/// <summary>
/// Represents a request to create a new products in the system.
/// </summary>
public class BaseSalesCartsRequest
{
    /// <summary>
    /// Gets the SalesNumber sales when the carts was created.
    /// </summary>
    public int? salesNumber;

    public int? SalesNumber
    {
        get
        {
            return salesNumber ?? new Random().Next(int.MaxValue); ;
        }

        set { salesNumber = value; }
    }

    /// <summary>
    /// Gets the branch sales when the carts was created.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime? Date { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public string UserId { get; set; }
}
