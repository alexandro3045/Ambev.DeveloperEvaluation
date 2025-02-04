using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProducts;

/// <summary>
/// Command for retrieving a list Products
/// </summary>
public record GetListProductCommand : IRequest<GetListProductResult>
{
    /// <summary>
    /// The page of the list
    /// </summary>
    public int Page { get; }

    /// <summary>
    /// The size of the list
    /// </summary>
    public int Size { get; }

    /// <summary>
    /// The order of the list
    /// </summary>
    public string? Order { get; }

    /// <summary>
    /// The direction of the field list
    /// </summary>
    public string? Direction { get; }

    /// <summary>
    /// The Filters of the field list
    /// </summary>
    public string? ColumnFilters { get; }


    /// <summary>
    /// Initializes a new instance of ListproductsCommand
    /// </summary>
    /// <param name="page">The page of the list of the list products to retrieve</param>
    /// <param name="size">The size of the list of the list products to retrieve</param>
    /// <param name="order">The order of the list of the list products to retrieve</param>
    /// <param name="direction">The Direction of the list of the list products to retrieve</param>
    /// <param name="columnFilters">The filter of the list of the list products to retrieve</param>
    /// <param name="searchTerm">The searchTerm of the list of the list products to retrieve</param>
    public GetListProductCommand(int page, int size, string? order, string? direction,
        string? columnFilters)
    {
        Page = page;
        Size = size;
        Order = order;
        Direction = direction;
        ColumnFilters = columnFilters;
    }
}



