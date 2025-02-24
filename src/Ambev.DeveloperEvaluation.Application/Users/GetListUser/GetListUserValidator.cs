using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.GetListUser;

/// <summary>
/// Validator for GetListUserCommand
/// </summary>
public class GetListUserValidator : AbstractValidator<GetListUserCommand>
{
    private string message = "{0} of the list is required";
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public GetListUserValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .WithMessage(string.Format(message, "Page"));

        RuleFor(x => x.Order)
            .NotEmpty()
            .WithMessage(string.Format(message, "Order"));

        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage(string.Format(message, "Size"));
    }
}
