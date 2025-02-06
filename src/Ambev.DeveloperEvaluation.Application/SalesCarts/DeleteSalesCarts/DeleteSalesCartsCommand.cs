using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Command for deleting a SalesCarts
/// </summary>
public record DeleteSalesCartsCommand : IRequest<DeleteSalesCartsResponse>
{
    /// <summary>
    /// The unique identifier of the SalesCarts to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteSalesCartsCommand
    /// </summary>
    /// <param name="id">The ID of the SalesCarts to delete</param>
    public DeleteSalesCartsCommand(Guid id)
    {
        Id = id;
    }
}
