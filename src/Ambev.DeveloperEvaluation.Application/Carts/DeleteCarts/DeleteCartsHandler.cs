using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCarts;

/// <summary>
/// Handler for processing DeleteCartsCommand requests
/// </summary>
public class DeleteCartsHandler : IRequestHandler<DeleteCartsCommand, DeleteCartsResponse>
{
    private readonly ICartsRepository _CartsRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    /// <summary>
    /// Initializes a new instance of DeleteCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="validator">The validator for DeleteCartsCommand</param>
    public DeleteCartsHandler( ICartsRepository CartsRepository, IMapper mapper, IMediator mediator)
    {
        _CartsRepository = CartsRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the DeleteCartsCommand request
    /// </summary>
    /// <param name="request">The DeleteCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteCartsResponse> Handle(DeleteCartsCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _CartsRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Carts with ID {request.Id} not found");

        var notification = _mapper.Map<BaseNotification>(new Domain.Entities.Carts { Id = request.Id });

        notification.Action = ActionNotification.Deleted;

        await _mediator.Publish(notification, cancellationToken);

        return new DeleteCartsResponse { Success = true };
    }
}
