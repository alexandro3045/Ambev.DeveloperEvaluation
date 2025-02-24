using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;

/// <summary>
/// Validator for DeleteProductsCommand
/// </summary>
public class DeleteProductsValidator : AbstractValidator<DeleteProductsCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteProductsCommand
    /// </summary>
    public DeleteProductsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ProductsItems ID is required");
    }
}
