using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Validator for UpdateSalesCartsRequest that defines validation rules for SalesCarts update.
/// </summary>
public class UpdateSalesCartsRequestValidator : AbstractValidator<UpdateSalesCartsRequest>
{
    private string message = $"{0} cannot be an empty field.";
    /// <summary>
    /// Initializes a new instance of the CreateSalesCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - CreatedAt: CreatedAt created
    /// - ProductsItems: ProductsItems relationed
    /// </remarks>
    public UpdateSalesCartsRequestValidator()
    {
        RuleFor(x => x.BranchId)
        .NotEmpty()
        .WithMessage(string.Format(message, "Branch"));

        RuleFor(x => x.Carts.Products)
            .NotEmpty()
            .WithMessage(string.Format(message, "Products"));

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(string.Format(message, "User Id"));

        RuleFor(SalesCarts => SalesCarts.salesNumber)
            .NotEmpty()
            .WithMessage(string.Format(message, "Sales Number"));
    }
}
