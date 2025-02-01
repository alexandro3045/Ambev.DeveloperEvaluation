using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;

/// <summary>
/// Command for deleting a user
/// </summary>
public record DeleteProductsCommand : IRequest<DeleteProductsResponse>
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProductsCommand
    /// </summary>
    /// <param name="id">The ID of the user to delete</param>
    public DeleteProductsCommand(Guid id)
    {
        Id = id;
    }
}
