using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Validator for UpdateSalesCartsRequest that defines validation rules for SalesCarts creation.
/// </summary>
public class UpdateSalesCartsRequestValidator : AbstractValidator<UpdateSalesCartsRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSalesCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - Date: Date created
    /// - Products: Products relationed
    /// </remarks>
    public UpdateSalesCartsRequestValidator()
    {
        RuleFor(SalesCartss => SalesCartss.Id).NotEmpty();
        RuleFor(SalesCartss => SalesCartss.UserId).NotEmpty().Length(1, 50);
        RuleFor(SalesCartss => SalesCartss.Date).NotEmpty();
        RuleFor(SalesCartss => SalesCartss.Products).NotEmpty();
    }
}