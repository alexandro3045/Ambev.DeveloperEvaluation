using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCarts;

/// <summary>
/// Command for deleting a carts
/// </summary>
public record DeleteCartsCommand : IRequest<DeleteCartsResponse>
{
    /// <summary>
    /// The unique identifier of the carts to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteCartsCommand
    /// </summary>
    /// <param name="id">The ID of the carts to delete</param>
    public DeleteCartsCommand(Guid id)
    {
        Id = id;
    }
}
