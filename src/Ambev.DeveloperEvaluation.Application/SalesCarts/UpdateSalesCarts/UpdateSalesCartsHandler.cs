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
    private readonly ISalesCartsRepository _SalesCartsRepository;
    private readonly ICartsProductsItemsRepository _CartsProductsItemsRepository;
    private readonly IProductRepository _ProductsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartsCommand</param>
    public UpdateCartsHandler(ISalesCartsRepository SalesCartsRepository,
        ICartsProductsItemsRepository CartsProductsItemsRepository,
        IMapper mapper,
        IProductRepository productsRepository)
    {
        _CartsProductsItemsRepository = CartsProductsItemsRepository;
        _SalesCartsRepository = SalesCartsRepository;
        _mapper = mapper;
        _ProductsRepository = productsRepository;
    }


    public async Task<UpdateSalesCartsResult> Handle(UpdateSalesCartsCommand command, CancellationToken cancellationToken)
    {
        var validationResult = command.Validate();

        if (!validationResult.IsValid)
        {
            throw new ValidationException("Campos:", validationResult.Errors.Select(e => new ValidationFailure(e.Error, e.Detail)).ToList());
        }

        var salesCarts = _mapper.Map<Domain.Entities.SalesCarts>(command);

        var existingSalesCarts = await _SalesCartsRepository.GetByPropertyValueAsync(p => p.SalesNumber == salesCarts.SalesNumber, cancellationToken);
        var salesCartSingle = existingSalesCarts.SingleOrDefault();
        if (salesCartSingle != null)
        {
            salesCarts.Id = salesCartSingle.Id;
            salesCarts.CartId = salesCartSingle.CartId;
        };

        salesCarts.Carts.CartsProductsItems.Clear();
        foreach (var cartItem in command.Products)
        {
            var items = await _CartsProductsItemsRepository.GetByCartIdProducIdAsync(salesCarts.CartId, cartItem.ProductId, cancellationToken);
            items.ForEach(Item =>
            {
                salesCarts.Carts.CartsProductsItems.Add(new CartsProductsItems { Id = Item.Id, CartId = Item.CartId, ProductId = cartItem.ProductId, Quantity = cartItem.Quantity, Product = Item.Product, Canceled = cartItem.Canceled });
            });
        }

        salesCarts.CalculateCart();

        var UpdatedCarts = await _SalesCartsRepository.UpdateAsync(salesCarts, cancellationToken);
        var result = _mapper.Map<UpdateSalesCartsResult>(UpdatedCarts);
        return result;
    }
}

