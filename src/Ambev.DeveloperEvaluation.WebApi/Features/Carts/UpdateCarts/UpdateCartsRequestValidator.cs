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
    /// - CreatedAt: CreatedAt created
    /// - ProductsItems: ProductsItems relationed
    /// </remarks>
    public UpdateCartsRequestValidator()
    {

        RuleFor(Carts => Carts.UserId).NotEmpty().Length(1, 50);

        RuleFor(Carts => Carts.CreatedAt).NotEmpty();

        RuleFor(Carts => Carts.Products).NotEmpty();
    }
}