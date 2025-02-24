using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Command for retrieving a ProductsItems by their ID
/// </summary>
public record GetProductsCommand : IRequest<GetProductsResult>
{
    /// <summary>
    /// The unique identifier of the ProductsItems to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetProductsCommand
    /// </summary>
    /// <param name="id">The ID of the ProductsItems to retrieve</param>
    public GetProductsCommand(Guid id)
    {
        Id = id;
    }
}
