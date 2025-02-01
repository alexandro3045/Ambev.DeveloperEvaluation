﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCarts;

/// <summary>
/// Validator for CreateCartsRequest that defines validation rules for Carts creation.
/// </summary>
public class CreateCartsRequestValidator : AbstractValidator<CreateCartsRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - Date: Date created
    /// - Products: Products relationed
    /// </remarks>
    public CreateCartsRequestValidator()
    {
        RuleFor(Carts => Carts.UserId).NotEmpty();
        RuleFor(Carts => Carts.Date).NotEmpty();
        RuleFor(Carts => Carts.Products).NotEmpty();
    }
}