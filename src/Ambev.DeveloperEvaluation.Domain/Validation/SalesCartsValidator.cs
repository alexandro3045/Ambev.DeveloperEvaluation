using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SalesCartsValidator : AbstractValidator<SalesCarts>
{
    private string _message = $" {0} must not be empty.";
    public SalesCartsValidator()
    {

        RuleFor(SalesCarts => SalesCarts.CartId)
            .NotEmpty()
            .WithMessage(string.Format(_message,"CartId"));

        RuleFor(SalesCarts => SalesCarts.UserId)
           .NotEmpty()
           .WithMessage(string.Format(_message, "SalesCarts.UserId"));

        RuleFor(SalesCarts => SalesCarts.BranchId)
            .NotEmpty()
            .WithMessage(string.Format(_message, "BranchId"));

        RuleFor(SalesCarts => SalesCarts.Carts)
            .NotEmpty()
            .WithMessage(string.Format(_message, "Carts"));

        RuleFor(SalesCarts => SalesCarts.Carts.CartsProductsItems)
            .NotEmpty()
            .WithMessage(string.Format(_message, "Carts products Items"));

        RuleFor(SalesCarts => SalesCarts.Carts.Id)
            .NotEmpty()
            .WithMessage(string.Format(_message, "SalesCarts => Carts.Id"));

        RuleFor(SalesCarts => SalesCarts.Carts.UserId)
           .NotEmpty()
           .WithMessage(string.Format(_message, "SalesCarts => Carts.UserId"));
    }
}
