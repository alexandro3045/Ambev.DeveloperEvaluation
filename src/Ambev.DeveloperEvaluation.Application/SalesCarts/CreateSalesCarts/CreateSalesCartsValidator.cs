using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;

/// <summary>
/// Validator for CreateSalesCartsCommand that defines validation rules for Carts creation command.
/// </summary>
public class CreateSalesCartsValidator : AbstractValidator<CreateSalesCartsCommand>
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
    public CreateSalesCartsValidator()
    {
        RuleFor(x => x.Products)
        .NotEmpty()
        .WithMessage(string.Format(message, "ProductsItems"));

        RuleFor(x => x.BranchId)
        .NotEmpty()
        .WithMessage(string.Format(message, "BranchId"));

        RuleFor(x => x.UserId)
        .NotEmpty()
        .WithMessage(string.Format(message, "UserId"));
    }
}