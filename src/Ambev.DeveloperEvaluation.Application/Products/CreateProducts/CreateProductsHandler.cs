using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
namespace Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;

/// <summary>
/// Handler for processing CreateProductsCommand requests
/// </summary>
public class CreateProductsHandler : IRequestHandler<CreateProductsCommand, CreateProductsResult>
{
    private readonly IProductRepository _ProductsRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of CreateProductsHandler
    /// </summary>
    /// <param name="ProductsRepository">The ProductsItems repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="mediator">The mediator instance</param>
    public CreateProductsHandler(IProductRepository ProductsRepository, IMapper mapper, IMediator mediator)
    {
        _ProductsRepository = ProductsRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the CreateProductsCommand request
    /// </summary>
    /// <param name="command">The CreateProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created ProductsItems details</returns>
    public async Task<CreateProductsResult> Handle(CreateProductsCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductsCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingProducts = await _ProductsRepository.GetByTitleAsync(command.Title, cancellationToken);
        if (existingProducts != null)
            throw new InvalidOperationException($"ProductsItems with title {command.Title} already exists");

        var Products = _mapper.Map<Domain.Entities.Product>(command);

        var createdProducts = await _ProductsRepository.CreateAsync(Products, cancellationToken);

        var notification = _mapper.Map<BaseNotification>(createdProducts);

        await _mediator.Publish(notification, cancellationToken);

        var result = _mapper.Map<CreateProductsResult>(createdProducts);

        return result;
    }
}
