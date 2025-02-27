using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Handler for processing UpdateCartsCommand requests
/// </summary>
public class UpdateCartsHandler : IRequestHandler<UpdateCartsCommand, UpdateCartsResult>
{
    private readonly ICartsRepository _CartsRepository;
    private readonly ICartsProductsItemsRepository _CartsProductsItemsRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of UpdateCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartsCommand</param>
    public UpdateCartsHandler(ICartsRepository CartsRepository, ICartsProductsItemsRepository CartsProductsItemsRepository, IMapper mapper, IMediator mediator)
    {
        _CartsProductsItemsRepository = CartsProductsItemsRepository;
        _CartsRepository = CartsRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the UpdateCartsCommand request
    /// </summary>
    /// <param name="command">The UpdateCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated Carts details</returns>
    public async Task<UpdateCartsResult> Handle(UpdateCartsCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartsValidator();

        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Carts = _mapper.Map<Domain.Entities.Carts>(command);

        Carts.CartsProductsItems.Clear();

        command.Products.ForEach(cartItem =>
        {
            _CartsProductsItemsRepository
               .GetByFilterAsync($"CartId={cartItem.CartId}&ProductId={cartItem.ProductId}", cancellationToken).ConfigureAwait(true)
               .GetAwaiter().GetResult().ForEach(Item =>
               {
                   Carts.CartsProductsItems.Add(new CartsProductsItems { Id = Item.Id, CartId = Item.CartId, ProductId = cartItem.ProductId, Quantity = cartItem.Quantity });
               });
        });

        var updatedCarts = await _CartsRepository.UpdateAsync(Carts, cancellationToken);

        var notification = _mapper.Map<BaseNotification>(updatedCarts);

        notification.Action = ActionNotification.Updated;

        await _mediator.Publish(notification, cancellationToken);

        var result = _mapper.Map<UpdateCartsResult>(updatedCarts);

        return result;
    }
}
