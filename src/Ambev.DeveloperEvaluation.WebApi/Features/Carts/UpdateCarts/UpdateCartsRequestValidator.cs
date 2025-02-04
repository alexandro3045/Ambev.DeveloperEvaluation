using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCards;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCarts;

/// <summary>
/// Validator for UpdateCartsRequest that defines validation rules for Carts creation.
/// </summary>
public class UpdateCartsRequestValidator : AbstractValidator<UpdateCartsRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - Date: Date created
    /// - Products: Products relationed
    /// </remarks>
    public UpdateCartsRequestValidator()
    {
        RuleFor(Cartss => Cartss.Id).NotEmpty();
        RuleFor(Cartss => Cartss.UserId).NotEmpty().Length(1, 50);
        RuleFor(Cartss => Cartss.Date).NotEmpty();
        RuleFor(Cartss => Cartss.Products).NotEmpty();
    }
}