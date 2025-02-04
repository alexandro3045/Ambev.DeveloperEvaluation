using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;

/// <summary>
/// Validator for GetListCartsRequest
/// </summary>
public class GetListCartsRequestValidator : AbstractValidator<GetListCartsRequest>
{
    /// <summary>
    /// Initializes validation rules for GetListCartsRequest
    /// </summary>
    public GetListCartsRequestValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .WithMessage("Page is required");

        RuleFor(x => x.Order)
            .NotEmpty()
            .WithMessage("Order is required");

        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage("Size is required");
    }
}
