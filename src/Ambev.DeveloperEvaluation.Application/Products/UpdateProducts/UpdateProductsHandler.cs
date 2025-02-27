using Ambev.DeveloperEvaluation.Application.Products.UpdateProducts;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Productss.UpdateProducts;

/// <summary>
/// Handler for processing UpdateProductsCommand requests
/// </summary>
public class UpdateProductHandler : IRequestHandler<UpdateProductsCommand, UpdateProductResult>
{
    private readonly IProductRepository _ProductsRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of UpdateProductsHandler
    /// </summary>
    /// <param name="ProductsRepository">The ProductsItems repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateProductsCommand</param>
    public UpdateProductHandler(IProductRepository ProductsRepository, IMapper mapper, IMediator mediator)
    {
        _ProductsRepository = ProductsRepository;
        _mapper = mapper;
        _mediator = mediator;
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

        var notification = _mapper.Map<BaseNotification>(UpdatedProducts);

        notification.Action = ActionNotification.Updated;

        await _mediator.Publish(notification, cancellationToken);

        var result = _mapper.Map<UpdateProductResult>(UpdatedProducts);

        return result;
    }
}
