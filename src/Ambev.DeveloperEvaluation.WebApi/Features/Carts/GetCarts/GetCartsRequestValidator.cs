using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Carts.GetCarts.GetCarts;

/// <summary>
/// Validator for GetCartsRequest
/// </summary>
public class GetCartsRequestValidator : AbstractValidator<GetCartsRequest>
{
    private string message = "{0} the is required";

    /// <summary>
    /// Initializes validation rules for GetCartsRequest
    /// </summary>
    public GetCartsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(string.Format(message, "Id"));
    }
}
