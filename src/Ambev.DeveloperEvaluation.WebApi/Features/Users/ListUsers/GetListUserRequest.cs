namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.LisUsers;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetListUserRequest
{
    /// <summary>
    /// The page user list to retrieve
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// The size user list to retrieve
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The order user list to retrieve
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// The direction user list to retrieve
    /// </summary>
    public string? Direction { get; set; }

    /// <summary>
    /// The filter Carts list to retrieve
    /// </summary>
    public string? ColumnFilters { get; set; }

    /// <summary>
    /// The filter Carts list to retrieve
    /// </summary>
    public string? SearchTerm { get; set; }
}
