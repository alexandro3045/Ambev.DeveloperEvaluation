using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductRequest that defines validation rules for Product creation.
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Productname: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
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
    public UpdateProductRequestValidator()
    {
        RuleFor(Products => Products.Title).NotEmpty().Length(1, 50);
        RuleFor(Products => Products.Price).NotEmpty().ScalePrecision(2, 100);
        RuleFor(Products => Products.Image).NotEmpty();
        RuleFor(Products => Products.Descripption).NotEmpty().Length(1, 100); ;
        RuleFor(Products => Products.Category).NotEmpty().Length(1, 100);
        RuleFor(Products => Products.Rating).NotEmpty();
    }
}