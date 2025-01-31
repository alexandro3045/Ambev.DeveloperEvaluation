using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListCategorias;

/// <summary>
/// Command for retrieving a list Products
/// </summary>
public record GetListCategoriesCommand : IRequest<GetListProductResult>
{
    /// <summary>
    /// The page of the list
    /// </summary>
    public int Page { get; } = default;

    /// <summary>
    /// The size of the list
    /// </summary>
    public int Size { get; } = default;

    /// <summary>
    /// The order of the list
    /// </summary>
    public string? Order { get; } = default;

    /// <summary>
    /// The direction of the field list
    /// </summary>
    public string? Direction { get; } = default;

    /// <summary>
    /// Initializes a new instance of ListproductsCommand
    /// </summary>
    /// <param name="page">The page of the list of the list products to retrieve</param>
    /// <param name="size">The size of the list of the list products to retrieve</param>
    /// <param name="order">The order of the list of the list products to retrieve</param>
    public GetListCategoriasCommand(int page, int size, string? order, string? direction)
    {
        Page = page;
        Size = size;
        Order = order;
        Direction = direction;
    }
}



