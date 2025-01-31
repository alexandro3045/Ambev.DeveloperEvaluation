using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.LisUsers;

/// <summary>
/// API response model for ListUser operation
/// </summary>
public class GetListUserResponse
{
    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public List<User> ListUser { get; set; }
}
