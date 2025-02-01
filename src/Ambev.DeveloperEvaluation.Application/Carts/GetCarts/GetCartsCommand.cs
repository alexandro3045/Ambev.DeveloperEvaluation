using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Command for retrieving a Carts by their ID
/// </summary>
public record GetCartsCommand : IRequest<GetCartsResult>
{
    /// <summary>
    /// The unique identifier of the Carts to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetCartsCommand
    /// </summary>
    /// <param name="id">The ID of the Carts to retrieve</param>
    public GetCartsCommand(Guid id)
    {
        Id = id;
    }
}
