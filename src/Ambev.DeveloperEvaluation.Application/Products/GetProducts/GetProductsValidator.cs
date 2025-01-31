using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Validator for GetProductsCommand
/// </summary>
public class GetProductsValidator : AbstractValidator<GetProductsCommand>
{
    /// <summary>
    /// Initializes validation rules for GetProductsCommand
    /// </summary>
    public GetProductsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Products ID is required");
    }
}
