using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCarts;

/// <summary>
/// Validator for DeleteCartsCommand
/// </summary>
public class DeleteCartsValidator : AbstractValidator<DeleteCartsCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteCartsCommand
    /// </summary>
    public DeleteCartsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Carts ID is required");
    }
}
