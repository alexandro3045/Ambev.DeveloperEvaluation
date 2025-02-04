using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetListProduct;

/// <summary>
/// Validator for GetListProductsRequest
/// </summary>
public class GetListProductsRequestValidator : AbstractValidator<GetListProductRequest>
{
    /// <summary>
    /// Initializes validation rules for GetListProductsRequest
    /// </summary>
    public GetListProductsRequestValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .WithMessage("Page is required");

        RuleFor(x => x.Order)
            .NotEmpty()
            .WithMessage("Order is required");

        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage("Size is required");
    }
}
