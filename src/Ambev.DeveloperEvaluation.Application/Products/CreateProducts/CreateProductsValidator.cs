using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;

/// <summary>
/// Validator for CreateProductsCommand that defines validation rules for Products creation command.
/// </summary>
public class CreateProductsCommandValidator : AbstractValidator<CreateProductsCommand>
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
    public CreateProductsCommandValidator()
    {
        RuleFor(Products => Products.Title).NotEmpty().Length(1, 50);
        RuleFor(Products => Products.Price).NotEmpty().ScalePrecision(2, 100);
        RuleFor(Products => Products.Image).NotEmpty();
        RuleFor(Products => Products.Descripption).NotEmpty().Length(1, 100); ;
        RuleFor(Products => Products.Category).NotEmpty().Length(1, 100);
        RuleFor(Products => Products.Rating).NotEmpty();
    }
}