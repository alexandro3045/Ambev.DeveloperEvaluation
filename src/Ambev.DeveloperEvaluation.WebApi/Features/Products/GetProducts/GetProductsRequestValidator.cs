using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Productss.GetProducts;

/// <summary>
/// Validator for GetProductsRequest
/// </summary>
public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
{
    /// <summary>
    /// Initializes validation rules for GetProductsRequest
    /// </summary>
    public GetProductsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Products ID is required");
    }
}
