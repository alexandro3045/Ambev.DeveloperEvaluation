using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Validator for UpdateSalesCartsCommand that defines validation rules for Carts creation command.
/// </summary>
public class UpdateSalesCartsValidator : AbstractValidator<UpdateSalesCartsCommand>
{

    private string message = $"{0} cannot be an empty field.";

    /// <summary>
    /// Initializes a new instance of the CreateCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - Date: Date created
    /// - ProductsItems: ProductsItems relationed
    /// </remarks>
    public UpdateSalesCartsValidator()
    {
        RuleFor(x => x.UpdatedAt)
            .NotEmpty()
            .WithMessage(string.Format(message, "Date"));

        RuleFor(x => x.Products)
            .NotEmpty()
            .WithMessage(string.Format(message, "Products"));

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(string.Format(message, "User Id"));

        RuleFor(x => x.SalesNumber)
         .NotEmpty()
         .WithMessage(string.Format(message, "Sales Number"));
    }
}