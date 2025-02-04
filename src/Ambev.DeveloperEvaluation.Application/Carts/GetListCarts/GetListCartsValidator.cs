using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetListCarts;

/// <summary>
/// Validator for GetCartsCommand
/// </summary>
public class GetListCartsValidator : AbstractValidator<GetListCartsCommand>
{
    private string message = "{0} of the list is required";
    /// <summary>
    /// Initializes validation rules for GetListCartsCommand
    /// </summary>
    public GetListCartsValidator()
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
