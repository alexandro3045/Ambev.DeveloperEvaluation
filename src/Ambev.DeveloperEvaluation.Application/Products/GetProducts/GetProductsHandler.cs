using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Productss.GetProducts;

/// <summary>
/// Handler for processing GetProductsCommand requests
/// </summary>
public class GetProductHandler : IRequestHandler<GetProductsCommand, GetProductsResult>
{
    private readonly IProductRepository _ProductsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductsHandler
    /// </summary>
    /// <param name="ProductsRepository">The ProductsItems repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetProductsCommand</param>
    public GetProductHandler(
        IProductRepository ProductsRepository,
        IMapper mapper)
    {
        _ProductsRepository = ProductsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductsCommand request
    /// </summary>
    /// <param name="request">The GetProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The ProductsItems details if found</returns>
    public async Task<GetProductsResult> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Products = await _ProductsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (Products == null)
            throw new KeyNotFoundException($"ProductsItems with ID {request.Id} not found");

        return _mapper.Map<GetProductsResult>(Products);
    }
}
