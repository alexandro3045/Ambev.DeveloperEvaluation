using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;

/// <summary>
/// Validator for CreateSalesCartsCommand that defines validation rules for Carts creation command.
/// </summary>
public class CreateSalesCartsValidator : AbstractValidator<CreateSalesCartsCommand>
{

    private string message = "{0} the list is required";

    /// <summary>
    /// Initializes a new instance of the CreateCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - Date: Date created
    /// - Products: Products relationed
    /// </remarks>
    public CreateSalesCartsValidator()
    {
        RuleFor(x => x.CreatedAt)
            .NotEmpty()
            .WithMessage(string.Format(message, "Date"));

        RuleFor(x => x.Products)
            .NotEmpty()
            .WithMessage(string.Format(message, "Products"));

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(string.Format(message, "UserId"));
    }
}