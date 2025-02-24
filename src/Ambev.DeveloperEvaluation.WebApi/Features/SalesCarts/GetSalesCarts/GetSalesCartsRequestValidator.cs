using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetSalesCarts;

/// <summary>
/// Validator for GetSalesCartsRequest
/// </summary>
public class GetSalesCartsRequestValidator : AbstractValidator<GetSalesCartsRequest>
{
    private string message = "{0} the is required";

    /// <summary>
    /// Initializes validation rules for GetSalesCartsRequest
    /// </summary>
    public GetSalesCartsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(string.Format(message, "Id"));
    }
}
