using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Application.Users.GetListUser;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProducts;

/// <summary>
/// Handler for processing GetProductCommand requests
/// </summary>
public class GetListProductHandler : IRequestHandler<GetListProductCommand, GetListProductResult>
{
    private readonly IProductsRepository _ProductsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetListProductsHandler
    /// </summary>
    /// <param name="ProductsRepository">The Products repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetProductsCommand</param>
    public GetListProductHandler(
        IProductsRepository ProductsRepository,
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
    /// <returns>The Products details if found</returns>
    public async Task<GetListProductResult> Handle(GetListProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetListProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var listUser = await _ProductsRepository.GetAllAsync(request.Page, request.Size, request.Order, request.Direction, cancellationToken);

        return _mapper.Map<GetListProductResult>(listUser);
    }
}
