using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;

/// <summary>
/// Validator for GetListSalesCartsRequest
/// </summary>
public class GetListSalesCartsRequestValidator : AbstractValidator<GetListSalesCartsRequest>
{
    /// <summary>
    /// Initializes validation rules for GetListSalesCartsRequest
    /// </summary>
    public GetListSalesCartsRequestValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .WithMessage("Page is required");

        RuleFor(x => x.Order)
            .NotEmpty()
            .WithMessage("Order is required");

        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage("Size is required");
    }
}
