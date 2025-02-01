using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

/// <summary>
/// Validator for CreateProductsRequest that defines validation rules for Products creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title:Required, length between 1 and 50 characters
    /// - Price: Required
    /// - Descripption: Required, length between 1 and 100 characters
    /// - Category: Required, length between 1 and 100 characters
    /// - Image: Required
    /// - Rating: Required
    /// </remarks>
    public CreateProductRequestValidator()
    {
        RuleFor(Products => Products.Title).NotEmpty().Length(1, 50);
        RuleFor(Products => Products.Price).NotEmpty().ScalePrecision(2, 100);
        RuleFor(Products => Products.Descripption).NotEmpty().Length(1, 100);
        RuleFor(Products => Products.Category).NotEmpty().Length(1, 100);
        RuleFor(Products => Products.Image).NotEmpty();
        RuleFor(Products => Products.Rating).NotEmpty();
    }
}