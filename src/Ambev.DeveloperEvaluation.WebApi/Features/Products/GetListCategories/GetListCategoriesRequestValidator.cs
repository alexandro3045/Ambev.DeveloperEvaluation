using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetListProduct;

/// <summary>
/// Validator for GetListCategoriesRequest
/// </summary>
public class GetListCategoriesRequestValidator : AbstractValidator<GetListCategoriesRequest>
{
    /// <summary>
    /// Initializes validation rules for GetListCategoriesRequest
    /// </summary>
    public GetListCategoriesRequestValidator()
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
