using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Handler for processing UpdateCartsCommand requests
/// </summary>
public class UpdateCartsHandler : IRequestHandler<UpdateCartsCommand, UpdateCartsResult>
{
    private readonly ICartsRepository _CartsRepository;
    private readonly ICartsProductsItemsRepository _CartsProductsItemsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartsCommand</param>
    public UpdateCartsHandler(ICartsRepository CartsRepository, ICartsProductsItemsRepository CartsProductsItemsRepository, IMapper mapper)
    {
        _CartsProductsItemsRepository = CartsProductsItemsRepository;
        _CartsRepository = CartsRepository;
        _mapper = mapper;
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

        command.Products.ForEach(async cartItem=>
        {
            _CartsProductsItemsRepository
               .GetByFilterAsync($"CartId={cartItem.CartId}&ProductId={cartItem.ProductId}", cancellationToken).ConfigureAwait(true)
               .GetAwaiter().GetResult().ForEach(async Item => {
                   Carts.CartsProductsItems.Add(new CartsProductsItems { Id = Item.Id, CartId = Item.CartId, ProductId = cartItem.ProductId, Quantity = cartItem.Quantity });
               });
        });

        
        var UpdatedCarts = await _CartsRepository.UpdateAsync(Carts, cancellationToken);

        var result = _mapper.Map<UpdateCartsResult>(UpdatedCarts);

        return result;
    }
}
