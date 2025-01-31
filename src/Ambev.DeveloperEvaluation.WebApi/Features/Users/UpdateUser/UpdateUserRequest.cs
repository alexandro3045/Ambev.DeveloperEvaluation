﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

/// <summary>
/// Represents a request to Update a new user in the system.
/// </summary>
public class UpdateUserRequest
{

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the username. Must be unique and contain only valid characters.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public Name Name { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// Gets or sets the password. Must meet security requirements.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number in format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address. Must be a valid email format.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the initial status of the user account.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the role assigned to the user.
    /// </summary>
    public UserRole Role { get; set; }
}