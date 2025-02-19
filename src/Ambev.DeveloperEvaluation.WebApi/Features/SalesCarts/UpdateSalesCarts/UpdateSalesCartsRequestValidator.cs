using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Validator for UpdateSalesCartsRequest that defines validation rules for Carts creation.
/// </summary>
public class UpdateSalesCartsRequestValidator : AbstractValidator<UpdateSalesCartsRequest>
{
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
        RuleFor(SalesCartss => SalesCartss.Id).NotEmpty();
    }
}