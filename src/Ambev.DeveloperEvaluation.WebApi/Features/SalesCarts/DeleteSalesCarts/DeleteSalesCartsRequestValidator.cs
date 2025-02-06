using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Validator for DeleteSalesCartsRequest
/// </summary>
public class DeleteSalesCartsRequestValidator : AbstractValidator<DeleteSalesCartsRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteSalesCartsRequest
    /// </summary>
    public DeleteSalesCartsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sales Carts ID is required");
    }
}
