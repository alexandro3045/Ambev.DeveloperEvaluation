using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCarts;

/// <summary>
/// Validator for DeleteCartsRequest
/// </summary>
public class DeleteCartsRequestValidator : AbstractValidator<DeleteCartsRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteCartsRequest
    /// </summary>
    public DeleteCartsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Carts ID is required");
    }
}
