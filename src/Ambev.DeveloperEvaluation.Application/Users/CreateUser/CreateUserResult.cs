using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Represents the response returned after successfully creating a new user.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateUserResult
{
    public CreateUserResult(Guid id, string userName, Name name, Address address, string email, string phone, UserRole role, UserStatus status)
    {
        Id = id;
        UserName = userName;
        Name = name;
        Address = address;
        Email = email;
        Phone = phone;
        Role = role;
        Status = status;
    }

    /// <summary>
    /// Gets or sets the unique identifier of the newly created user.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created user in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's full name
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The user's name
    /// </summary>
    public Name Name { get; set; }

    /// <summary>
    /// The user's  address
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// The user's email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// The current status of the user
    /// </summary>
    public UserStatus Status { get; set; }
}
