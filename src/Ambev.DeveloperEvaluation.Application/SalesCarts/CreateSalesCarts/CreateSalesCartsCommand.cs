using Ambev.DeveloperEvaluation.Application.SalesCarts.Carts;
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
public class CreateSalesCartsCommand : SalesCartsCommand, IRequest<CreateSalesCartsResult>
{
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