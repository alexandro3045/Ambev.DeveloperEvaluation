using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Handler for processing UpdateSalesCartsCommand requests
/// </summary>
public class UpdateCartsHandler : IRequestHandler<UpdateSalesCartsCommand, UpdateSalesCartsResult>
{
    private readonly ISalesCartsRepository _salesCartsRepository;
    private readonly ICartsProductsItemsRepository _cartsProductsItemsRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of UpdateCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartsCommand</param>
    public UpdateCartsHandler(ISalesCartsRepository SalesCartsRepository,
        ICartsProductsItemsRepository CartsProductsItemsRepository,
        IProductRepository productsRepository, IMapper mapper, IMediator mediator)
    {
        _cartsProductsItemsRepository = CartsProductsItemsRepository;
        _salesCartsRepository = SalesCartsRepository;
        _mapper = mapper;
        _mediator = mediator;
    }


    public async Task<UpdateSalesCartsResult> Handle(UpdateSalesCartsCommand command, CancellationToken cancellationToken)
    {
        var validationResult = command.Validate();

        if (!validationResult.IsValid)
        {
            throw new ValidationException("Campos:", validationResult.Errors.Select(e => new ValidationFailure(e.Error, e.Detail)).ToList());
        }

        var salesCarts = _mapper.Map<Domain.Entities.SalesCarts>(command);

        var existingSalesCarts = await _salesCartsRepository.GetByPropertyValueAsync(p => p.SalesNumber == salesCarts.SalesNumber, cancellationToken);
        var salesCartSingle = existingSalesCarts.SingleOrDefault();
        if (salesCartSingle != null)
        {
            salesCarts.Id = salesCartSingle.Id;
            salesCarts.CartId = salesCartSingle.CartId;
        };

        salesCarts.Carts.CartsProductsItems.Clear();
        foreach (var cartItem in command.Products)
        {
            var items = await _cartsProductsItemsRepository.GetByCartIdProducIdAsync(salesCarts.CartId, cartItem.ProductId, cancellationToken);
            items.ForEach(Item =>
            {
                salesCarts.Carts.CartsProductsItems.Add(new CartsProductsItems { Id = Item.Id, CartId = Item.CartId, ProductId = cartItem.ProductId, Quantity = cartItem.Quantity, Product = Item.Product, Canceled = cartItem.Canceled });
            });
        }

        salesCarts.CalculateCart();

        var updatedSalesCarts = await _salesCartsRepository.UpdateAsync(salesCarts, cancellationToken);

        var notification = _mapper.Map<BaseNotification>(updatedSalesCarts);

        notification.Action = ActionNotification.Updated;

        await _mediator.Publish(notification, cancellationToken);

        var result = _mapper.Map<UpdateSalesCartsResult>(updatedSalesCarts);
        
        return result;
    }
}

