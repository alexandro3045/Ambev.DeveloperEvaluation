using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetListUser;

/// <summary>
/// Command for retrieving a user by their Page, Size and Order
/// </summary>
public record GetListUserCommand : IRequest<GetListUserResult>
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
    /// The Filters of the field list
    /// </summary>
    public string? SearchTerm { get; }

    /// <summary>
    /// Initializes a new instance of ListUserCommand
    /// </summary>
    /// <param name="page">The page of the list of the list user to retrieve</param>
    /// <param name="size">The size of the list of the list user to retrieve</param>
    /// <param name="order">The order of the list of the list user to retrieve</param>
    public GetListUserCommand(int page, int size, string? order, string? direction,
        string? columnFilters, string? searchTerm)
    {
        Page = page;
        Size = size;
        Order = order;
        Direction = direction;
        ColumnFilters = columnFilters;
        SearchTerm = searchTerm;
    }
}
