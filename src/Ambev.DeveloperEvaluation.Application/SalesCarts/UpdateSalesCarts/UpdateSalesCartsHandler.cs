using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Handler for processing UpdateSalesCartsCommand requests
/// </summary>
public class UpdateCartsHandler : IRequestHandler<UpdateSalesCartsCommand, UpdateSalesCartsResult>
{
    private readonly ISalesCartsRepository _SalesCartsRepository;
    private readonly ICartsProductsItemsRepository _CartsProductsItemsRepository;
    private readonly IProductsRepository _ProductsRepository;
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
        IProductsRepository productsRepository)
    {
        _CartsProductsItemsRepository = CartsProductsItemsRepository;
        _SalesCartsRepository = SalesCartsRepository;
        _mapper = mapper;
        _ProductsRepository = productsRepository;
    }

    /// <summary>
    /// Handles the UpdateSalesCartsCommand request
    /// </summary>
    /// <param name="command">The UpdateCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated Sales Carts details</returns>
    public async Task<UpdateSalesCartsResult> Handle(UpdateSalesCartsCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSalesCartsValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
       
        var salesCarts = _mapper.Map<Domain.Entities.SalesCarts>(command);

        salesCarts.Carts.CartsProductsItems.Clear();
        command.Products.ForEach(async cartItem =>
        { 
            _CartsProductsItemsRepository
               .GetByCartIdProducIdAsync(salesCarts.CartId,cartItem.ProductId, cancellationToken)
               .GetAwaiter().GetResult().ForEach(async Item =>
               {
                   salesCarts.Carts.CartsProductsItems.Add(new CartsProductsItems { Id = Item.Id, CartId = Item.CartId, ProductId = cartItem.ProductId, Quantity = cartItem.Quantity, Product = Item.Product });
               });
        });

        salesCarts.CalculateCart();

        var UpdatedCarts = await _SalesCartsRepository.UpdateAsync(salesCarts, cancellationToken);
        var result = _mapper.Map<UpdateSalesCartsResult>(UpdatedCarts);
        return result;
    }
}

