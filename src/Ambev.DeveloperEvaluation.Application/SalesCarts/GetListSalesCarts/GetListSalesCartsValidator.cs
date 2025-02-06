using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;

/// <summary>
/// Validator for GetListSalesCommand
/// </summary>
public class GetListSalesCartsValidator : AbstractValidator<GetListSalesCartsCommand>
{
    private string message = "{0} of the list is required";
    /// <summary>
    /// Initializes validation rules for GetListSalesCommand
    /// </summary>
    public GetListSalesCartsValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .WithMessage(string.Format(message, "Page"));

        RuleFor(x => x.Order)
            .NotEmpty()
            .WithMessage(string.Format(message, "Order"));

        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage(string.Format(message, "Size"));
    }
}
