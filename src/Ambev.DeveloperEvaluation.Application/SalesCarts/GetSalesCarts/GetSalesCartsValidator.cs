using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;

/// <summary>
/// Validator for GetSalesCartsCommand
/// </summary>
public class GetSalesCartsValidator : AbstractValidator<GetSalesCartsCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSalesCartsCommand
    /// </summary>
    public GetSalesCartsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Carts ID is required");
    }
}
