using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;

/// <summary>
/// Represents a request to create a new Carts in the system.
/// </summary>
public class CreateSalesCartsRequest
{
    public CreateSalesCartsRequest()
    {
        salesNumber = new Random().Next(int.MaxValue);
    }

    /// <summary>
    /// Gets the SalesNumber sales when the carts was created.
    /// </summary>
    private int salesNumber;

    public required int SalesNumber
    {
        get
        {
            return salesNumber;
        }

        set { salesNumber = value; }
    }

    /// <summary>
    /// Gets the branch sales when the carts was created.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets the Carts when the sales was created.
    /// </summary>
    public required CartsRequest Carts { get; set; }
}
