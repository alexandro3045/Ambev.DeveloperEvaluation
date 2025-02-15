using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;

/// <summary>
/// Command for create a Carts.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for create a Carts, 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSalesCartsResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSalesCartsCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSalesCartsCommand : IRequest<CreateSalesCartsResult>
{
    /// <summary>
    /// Gets the SalesNumber sales when the carts was created.
    /// </summary>
    public required int SalesNumber { get; set; }

    /// <summary>
    /// Gets the branch sales when the carts was created.
    /// </summary>
    public Guid BranchId { get; set; }

    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets the products when the carts was created.
    /// </summary>
    public List<CartItem> Products { get; set; }

    /// <summary>
    /// Gets the Carts when the carts was created.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var result = Validate();

        var validator = new CreateSalesCartsValidator();

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}