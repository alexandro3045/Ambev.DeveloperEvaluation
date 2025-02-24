using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Validator for DeleteSalesCartsCommand
/// </summary>
public class DeleteSalesCartsValidator : AbstractValidator<DeleteSalesCartsCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteSalesCartsCommand
    /// </summary>
    public DeleteSalesCartsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sales Carts ID is required");
    }
}
