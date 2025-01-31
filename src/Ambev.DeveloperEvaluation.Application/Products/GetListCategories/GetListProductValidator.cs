using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProducts;

/// <summary>
/// Validator for GetProductsCommand
/// </summary>
public class GetListProductValidator : AbstractValidator<GetListProductCommand>
{
    private string message = "{0} of the list is required";
    /// <summary>
    /// Initializes validation rules for GetListProductsCommand
    /// </summary>
    public GetListProductValidator()
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
