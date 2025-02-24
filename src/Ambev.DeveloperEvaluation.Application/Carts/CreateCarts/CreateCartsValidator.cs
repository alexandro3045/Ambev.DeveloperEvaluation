using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

/// <summary>
/// Validator for CreateCartsCommand that defines validation rules for Carts creation command.
/// </summary>
public class CreateCartsCommandValidator : AbstractValidator<CreateCartsCommand>
{
    private string message = "{0} is required";
    /// <summary>
    /// Initializes a new instance of the CreateCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - Date: Date created
    /// - ProductsItems: ProductsItems relationed
    /// </remarks>
    public CreateCartsCommandValidator()
    {
        RuleFor(Carts => Carts.UserId)
            .NotEmpty()
            .Length(1, 50)
            .WithMessage(string.Format(message, "UserId"));

        RuleFor(Carts => Carts.CreatedAt)
            .NotEmpty()
            .WithMessage(string.Format(message, "CreatedAt"));

        RuleFor(Carts => Carts.Products)
            .NotEmpty()
            .WithMessage(string.Format(message, "ProductsItems"));
    }
}