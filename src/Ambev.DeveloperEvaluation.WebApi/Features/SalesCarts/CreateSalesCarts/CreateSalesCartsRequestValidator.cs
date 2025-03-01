﻿using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateSalesCarts;

/// <summary>
/// Validator for CreateSalesCartsRequest that defines validation rules for Carts creation.
/// </summary>
public class CreateSalesCartsRequestValidator : AbstractValidator<CreateSalesCartsRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSalesCartsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserID:Required, UserID User
    /// - CreatedAt: CreatedAt created
    /// - ProductsItems: ProductsItems relationed
    /// </remarks>
    public CreateSalesCartsRequestValidator()
    {
        RuleFor(SalesCarts => SalesCarts.SalesNumber)
            .NotEmpty()
            .WithMessage("O número da venda não pode ser um campo vazio.");

        RuleFor(SalesCarts => SalesCarts.BranchId)
            .NotEmpty()
            .WithMessage("A filial não pode ser um campo vazio.");

        RuleFor(SalesCarts => SalesCarts.Carts.Products)
            .NotEmpty()
            .WithMessage("O carrinho não pode estar sem produtos.");

    }
}