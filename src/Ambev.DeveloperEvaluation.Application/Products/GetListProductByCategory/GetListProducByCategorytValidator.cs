using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProductsByCategory;

/// <summary>
/// Validator for GetProductsByCategoryommand
/// </summary>
public class GetListProducByCategorytValidator : AbstractValidator<GetListProductByCategoryCommand>
{
    private string message = "{0} the list is required";
    /// <summary>
    /// Initializes validation rules for GetListProductsCommand
    /// </summary>
    public GetListProducByCategorytValidator()
    {
        RuleFor(x => x.Category)
        .NotEmpty()
        .WithMessage(string.Format(message, "Category"));

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
