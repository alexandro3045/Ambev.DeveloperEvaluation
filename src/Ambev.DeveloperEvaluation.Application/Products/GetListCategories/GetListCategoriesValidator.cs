using Ambev.DeveloperEvaluation.Application.Products.GetListCategorias;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetListCategories;

/// <summary>
/// Validator for GetCategoriesCommand
/// </summary>
public class GetListCategoriesValidator : AbstractValidator<GetListCategoriesCommand>
{
    private string message = "{0} of the list is required";
    /// <summary>
    /// Initializes validation rules for GetListCategoriesCommand
    /// </summary>
    public GetListCategoriesValidator()
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
