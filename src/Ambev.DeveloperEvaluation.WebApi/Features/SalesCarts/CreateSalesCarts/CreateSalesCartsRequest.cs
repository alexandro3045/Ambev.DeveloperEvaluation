using Ambev.DeveloperEvaluation.WebApi.Features.Branch.CreateBranchRequest;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;

/// <summary>
/// Represents a request to create a new SalesCarts in the system.
/// </summary>
public class CreateSalesCartsRequest
{
    /// <summary>
    /// Gets the SalesNumber sales when the carts was created.
    /// </summary>
    public required int SalesNumber { get; set; } = new Random().Next(1,10000);

    /// <summary>
    /// Gets the branch sales when the carts was created.
    /// </summary>
    public CreateBranchRequest Branch { get; set; }

    /// <summary>
    /// Gets the Carts when the carts was created.
    /// </summary>
    public CreateCartsRequest Carts { get; set; }
}
