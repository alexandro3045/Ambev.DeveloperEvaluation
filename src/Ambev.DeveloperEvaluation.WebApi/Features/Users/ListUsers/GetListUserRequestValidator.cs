using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.LisUsers;

/// <summary>
/// Validator for GetListUserRequest
/// </summary>
public class GetListUserRequestValidator : AbstractValidator<GetListUserRequest>
{
    /// <summary>
    /// Initializes validation rules for GetListUserRequest
    /// </summary>
    public GetListUserRequestValidator()
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
