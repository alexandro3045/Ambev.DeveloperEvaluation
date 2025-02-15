using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Command for deleting a Carts
/// </summary>
public record DeleteSalesCartsCommand : IRequest<DeleteSalesCartsResponse>
{
    /// <summary>
    /// The unique identifier of the Carts to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteSalesCartsCommand
    /// </summary>
    /// <param name="id">The ID of the Carts to delete</param>
    public DeleteSalesCartsCommand(Guid id)
    {
        Id = id;
    }
}
