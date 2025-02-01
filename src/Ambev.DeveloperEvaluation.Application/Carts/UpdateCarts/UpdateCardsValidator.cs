using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Validator for UpdateCartsCommand that defines validation rules for Carts creation command.
/// </summary>
public class UpdateCartsValidator : AbstractValidator<UpdateCartsCommand>
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
    public UpdateCartsValidator()
    {
        RuleFor(Carts => Carts.UserId).NotEmpty();
        RuleFor(Carts => Carts.Date).NotEmpty();
        RuleFor(Carts => Carts.Products).NotEmpty();
    }
}