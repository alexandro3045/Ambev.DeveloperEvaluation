﻿using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Command for update a SalesCarts.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for update a SalesCarts, 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateSalesCartsResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateSalesCartsCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateSalesCartsCommand : IRequest<UpdateSalesCartsResult>
{
    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time when the carts was updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets the Customer when the carts was created.
    /// </summary>
    public string Customer { get; set; }

    /// <summary>
    /// Gets the total sales when the carts was created.
    /// </summary>
    public decimal TotalSales { get; set; }

    /// <summary>
    /// Gets the branch sales when the carts was created.
    /// </summary>
    public Branch Branch { get; set; }

    /// <summary>
    /// Gets the products when the carts was created.
    /// </summary>
    public IList<Product> Products { get; set; }

    /// <summary>
    /// Gets the quantities products when the carts was created.
    /// </summary>
    public int Quantities { get; set; }

    /// <summary>
    /// Gets the unit price products when the carts was created.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the Discounts products when the carts was created.
    /// </summary>
    public decimal Discounts { get; set; }

    /// <summary>
    /// Gets the Total amount item products when the carts was created.
    /// </summary>
    public decimal TotalAmountItem { get; set; }

    /// <summary>
    /// Gets the canceled item products when the carts was created.
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