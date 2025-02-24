using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartsValidator : AbstractValidator<Carts>
{
    public CartsValidator()
    {

        RuleFor(Carts => Carts.UserId)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Cartsname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Cartsname cannot be longer than 50 characters.");

        RuleFor(Carts => Carts.CartsProductsItems)
            .NotEmpty()
            .WithMessage("Carts producs itens must be required.");
    }
}
