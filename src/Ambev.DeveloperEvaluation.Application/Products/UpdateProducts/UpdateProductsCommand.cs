using Ambev.DeveloperEvaluation.Application.Products.UpdateProducts;
using Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

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
public class UpdateProductsCommand : IRequest<UpdateProductResult>
{

    /// <summary>
    /// Gets or sets the id of the product to be update.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets the Title from product
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets the price from product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the description from product.
    /// </summary>
    public string Descripption { get; set; }

    /// <summary>
    /// Gets the category from product.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets the image from product.
    /// </summary>
    public string Image { get; set; }

    [Column(TypeName = "jsonb")]
    public Rating Rating { get; set; }

    public ValidationResultDetail Validate()
    {
        var result = Validate();

        var validator = new UpdateProductsValidator();

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}