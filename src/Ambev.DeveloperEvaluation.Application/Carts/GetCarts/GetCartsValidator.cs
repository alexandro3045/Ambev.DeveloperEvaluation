using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Validator for GetCartsCommand
/// </summary>
public class GetCartsValidator : AbstractValidator<GetCartsCommand>
{
    /// <summary>
    /// Initializes validation rules for GetCartsCommand
    /// </summary>
    public GetCartsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Carts ID is required");
    }
}
