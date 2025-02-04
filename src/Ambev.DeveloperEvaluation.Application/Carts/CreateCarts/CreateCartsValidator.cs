using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

/// <summary>
/// Validator for CreateCartsCommand that defines validation rules for Carts creation command.
/// </summary>
public class CreateCartsCommandValidator : AbstractValidator<CreateCartsCommand>
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
    public CreateCartsCommandValidator()
    {
        RuleFor(Carts => Carts.UserId).NotEmpty().Length(1, 50);
        RuleFor(Carts => Carts.CreatedAt).NotEmpty();
        RuleFor(Carts => Carts.Products).NotEmpty();
    }
}