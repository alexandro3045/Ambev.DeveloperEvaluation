using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

/// <summary>
/// Command for creating a new Carts.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a Carts, 
/// including Cartsname, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateCartsResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateCartsCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateCartsCommand : IRequest<CreateCartsResult>
{
    /// <summary>
    /// Gets the Id when the carts was updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the UserId from user
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets the createdAt from carts
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the List from product.
    /// </summary>
    public required List<CartItem> Products { get; set; }

    public virtual ValidationResultDetail Validate()
    {
        var validator = new CreateCartsCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}

public class CartItem
{
    public CartItem(Guid cartId, Guid productId, int quantity)
    {
        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
    }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}