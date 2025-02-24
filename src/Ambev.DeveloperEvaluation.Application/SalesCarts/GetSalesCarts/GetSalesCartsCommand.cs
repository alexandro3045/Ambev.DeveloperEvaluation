using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;

/// <summary>
/// Command for retrieving a Carts by their ID
/// </summary>
public record GetSalesCartsCommand : IRequest<GetSalesCartsResult>
{
    /// <summary>
    /// The unique identifier of the Carts to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetCartsCommand
    /// </summary>
    /// <param name="id">The ID of the Carts to retrieve</param>
    public GetSalesCartsCommand(Guid id)
    {
        Id = id;
    }
}
