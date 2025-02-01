using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Command for creating a new Carts.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a Carts, 
/// including Dat, UserId,Users and Products. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateCartsResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateCartsCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateCartsCommand : IRequest<UpdateCartsResult>
{

    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets the User when the carts was created.
    /// </summary>
    public string User { get; set; }

    /// <summary>
    /// Gets the Products when the carts was created.
    /// </summary>
    public List<Product> Products { get; set; }

    public ValidationResultDetail Validate()
    {
        var result = Validate();

        var validator = new UpdateCartsValidator();

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}