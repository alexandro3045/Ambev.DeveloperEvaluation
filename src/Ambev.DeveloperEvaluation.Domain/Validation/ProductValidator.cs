using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    private string message = "{0} must be required.";
    private string messagemin = "{0} must be at least 5 characters long.";
    private string messagemax = "{0} cannot be longer than {1} characters.";
    public ProductValidator()
    {
        RuleFor(Product => Product.Title)
            .NotEmpty()
            .WithMessage(string.Format(message, "Title"));

        RuleFor(Product => Product.Title)
            .NotEmpty()
            .MinimumLength(5).WithMessage(string.Format(messagemin, "Title"))
            .MaximumLength(50).WithMessage(string.Format(messagemax, "Title", "50"));

        RuleFor(Product => Product.Price)
            .NotEmpty()
            .WithMessage(string.Format(message, "Price"));

        RuleFor(Product => Product.Description)
            .NotEmpty()
            .WithMessage(string.Format(message, "Description"));

        RuleFor(Product => Product.Description)
            .NotEmpty()
            .MinimumLength(5).WithMessage(string.Format(messagemin, "Description"))
            .MaximumLength(50).WithMessage(string.Format(messagemax, "Description", "100"));

        RuleFor(Product => Product.Category)
            .NotEmpty()
            .WithMessage(string.Format(message, "Category"));

        RuleFor(Product => Product.Category)
            .NotEmpty()
            .MinimumLength(5).WithMessage(string.Format(messagemin, "Category"))
            .MaximumLength(50).WithMessage(string.Format(messagemax, "Category", "20"));


        RuleFor(Product => Product.Image)
            .NotEmpty()
            .WithMessage(string.Format(message, "Image"));

        RuleFor(Product => Product.Image)
            .NotEmpty()
            .MinimumLength(5).WithMessage(string.Format(messagemin, "Image"))
            .MaximumLength(50).WithMessage(string.Format(messagemax, "Image", "1000"));

        RuleFor(Product => Product.Rating)
            .NotEmpty()
            .WithMessage(string.Format(message, "Rating"));

        RuleFor(Product => Product.CreatedAt)
            .NotEmpty()
            .WithMessage(string.Format(message, "CreatedAt"));

    }
}
