using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Validator for UpdateCartsCommand that defines validation rules for Carts creation command.
/// </summary>
public class UpdateCartsValidator : AbstractValidator<UpdateCartsCommand>
{

    private string message = "{0} the list is required";

    /// <summary>
    /// Initializes a new instance of the CreateCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - Date: Date created
    /// - ProductsItems: ProductsItems relationed
    /// </remarks>
    public UpdateCartsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(string.Format(message, "Id"));

        RuleFor(x => x.CreatedAt)
            .NotEmpty()
            .WithMessage(string.Format(message, "Date"));

        RuleFor(x => x.Products)
            .NotEmpty()
            .WithMessage(string.Format(message, "ProductsItems"));

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(string.Format(message, "UserId"));
    }
}