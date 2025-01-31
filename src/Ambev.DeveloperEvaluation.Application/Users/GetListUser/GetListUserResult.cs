using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Users.GetListUser;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetListUserResult
{
    /// <summary>
    /// The list user
    /// </summary>
    public List<User>? ListUser { get; set; }

    public GetListUserResult(List<User>? listUser)
    {
        ListUser = listUser;
    }

}
