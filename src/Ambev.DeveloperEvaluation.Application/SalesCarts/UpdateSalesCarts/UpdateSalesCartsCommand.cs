using Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.Carts;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Command for update a Carts.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for update a Carts, 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateSalesCartsResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateSalesCartsCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateSalesCartsCommand : SalesCartsCommand, IRequest<UpdateSalesCartsResult>
{    
    /// <summary>
    /// Gets the date and time when the carts was updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets the canceled and time when the carts was updated.
    /// </summary>
    public bool Canceled { get; set; }

    public ValidationResultDetail Validate()
    {
        var result = Validate();

        var validator = new UpdateSalesCartsValidator();

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}