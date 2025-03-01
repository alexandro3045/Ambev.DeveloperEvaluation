using Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Productss.DeleteProducts;

/// <summary>
/// Handler for processing DeleteProductsCommand requests
/// </summary>
public class DeleteProductsHandler : IRequestHandler<DeleteProductsCommand, DeleteProductsResponse>
{
    private readonly IProductRepository _ProductsRepository;

    /// <summary>
    /// Initializes a new instance of DeleteProductsHandler
    /// </summary>
    /// <param name="ProductsRepository">The ProductsItems repository</param>
    /// <param name="validator">The validator for DeleteProductsCommand</param>
    public DeleteProductsHandler(
        IProductRepository ProductsRepository)
    {
        _ProductsRepository = ProductsRepository;
    }

    /// <summary>
    /// Handles the DeleteProductsCommand request
    /// </summary>
    /// <param name="request">The DeleteProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteProductsResponse> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _ProductsRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"ProductsItems with ID {request.Id} not found");

        return new DeleteProductsResponse { Success = true };
    }
}
