using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Handler for processing DeleteSalesCartsCommand requests
/// </summary>
public class DeleteSalesCartsHandler : IRequestHandler<DeleteSalesCartsCommand, DeleteSalesCartsResponse>
{
    private readonly ISalesCartsRepository _salesCartsRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of DeleteSalesCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The Carts repository</param>
    /// <param name="validator">The validator for DeleteSalesCartsCommand</param>
    public DeleteSalesCartsHandler(ISalesCartsRepository SalesCartsRepository,IMapper mapper, IMediator mediator)
    {
        _salesCartsRepository = SalesCartsRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the DeleteSalesCartsCommand request
    /// </summary>
    /// <param name="request">The DeleteSalesCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSalesCartsResponse> Handle(DeleteSalesCartsCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSalesCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var successDelete = await _salesCartsRepository.DeleteAsync(request.Id, cancellationToken);

        if (!successDelete)
            throw new KeyNotFoundException($"Sales not deleted with ID {request.Id} ");

        var notification = _mapper.Map<BaseNotification>(new Domain.Entities.SalesCarts { Id = request.Id });

        notification.Action = ActionNotification.Deleted;

        await _mediator.Publish(notification, cancellationToken);

        return new DeleteSalesCartsResponse { Success = true };
    }
}
