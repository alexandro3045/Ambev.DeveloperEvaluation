using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProducts;
using Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Productss.UpdateProducts;

/// <summary>
/// Command for creating a new Products.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a Products, 
/// including Productsname, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateProductsResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateProductsCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateProductsCommand : CreateProductsCommand, IRequest<UpdateProductsResult>
{
    public override ValidationResultDetail Validate()
    {
        var result = base.Validate();

        var validator = new UpdateProductsValidator();

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}