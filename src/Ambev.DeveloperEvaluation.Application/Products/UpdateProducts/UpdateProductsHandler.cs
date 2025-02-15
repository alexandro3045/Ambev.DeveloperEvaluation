using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProducts;


namespace Ambev.DeveloperEvaluation.Application.Productss.UpdateProducts;

/// <summary>
/// Handler for processing UpdateProductsCommand requests
/// </summary>
public class UpdateProductHandler : IRequestHandler<UpdateProductsCommand, UpdateProductResult>
{
    private readonly IProductsRepository _ProductsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateProductsHandler
    /// </summary>
    /// <param name="ProductsRepository">The ProductsItems repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateProductsCommand</param>
    public UpdateProductHandler(IProductsRepository ProductsRepository, IMapper mapper)
    {
        _ProductsRepository = ProductsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateProductsCommand request
    /// </summary>
    /// <param name="command">The UpdateProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated ProductsItems details</returns>
    public async Task<UpdateProductResult> Handle(UpdateProductsCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductsValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
       
        var Products = _mapper.Map<Domain.Entities.Product>(command);

        var UpdatedProducts = await _ProductsRepository.UpdateAsync(Products, cancellationToken);
        var result = _mapper.Map<UpdateProductResult>(UpdatedProducts);
        return result;
    }
}
