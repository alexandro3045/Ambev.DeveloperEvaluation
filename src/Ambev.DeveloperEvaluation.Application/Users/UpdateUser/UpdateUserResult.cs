namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Represents the response returned after successfully update a user.
/// </summary>
/// <remarks>
/// This response contains  Updated user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateUserResult
{
    /// <summary>
    /// Gets or sets the succces the Updated user.
    /// </summary>
    /// <value>A success operation</value>
    public bool succes { get; set; }
}
