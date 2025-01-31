using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;

/// <summary>
/// Validator for DeleteProductsRequest
/// </summary>
public class DeleteProductsRequestValidator : AbstractValidator<DeleteProductsRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProductsRequest
    /// </summary>
    public DeleteProductsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Products ID is required");
    }
}
