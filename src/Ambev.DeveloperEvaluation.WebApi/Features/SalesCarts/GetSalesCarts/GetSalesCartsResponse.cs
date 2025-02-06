using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.SalesCarts.GetSalesCarts;

/// <summary>
/// API response model for GetSalesCarts operation
/// </summary>
public class GetSalesCartsResponse
{

    /// <summary>
    /// Gets the Id when the salescarts was created.
    /// </summary>
    public required Guid Id { get; set; }


    /// <summary>
    /// Gets the UserId when the salescarts was created.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets the date and time when the salescarts was created.
    /// </summary>
    public DateTime Date { get; set; }


    /// <summary>
    /// Gets the products when the salescarts was created.
    /// </summary>
    public required List<Item> Products { get; set; }
}
