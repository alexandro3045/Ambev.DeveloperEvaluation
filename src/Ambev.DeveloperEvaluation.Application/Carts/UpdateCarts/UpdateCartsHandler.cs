using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Handler for processing UpdateCartsCommand requests
/// </summary>
public class UpdateCartsHandler : IRequestHandler<UpdateCartsCommand, UpdateCartsResult>
{
    private readonly ICartsRepository _CartsRepository;
    private readonly IProductsRepository _ProductsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartsCommand</param>
    public UpdateCartsHandler(ICartsRepository CartsRepository, IProductsRepository _ProductsRepository, IMapper mapper)
    {
        _ProductsRepository = _ProductsRepository;
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
        var i = command.Products.Select(p => p.ProductId).ToArray();
        _ProductsRepository.GetByProductsIds(i);
        Carts.CartsProductsItemns =  command.Products.Select(p => new Domain.Entities.CartsProductItem { ProductId = p.ProductId, Quantity = p.Quantity }).ToList();
        
        var UpdatedCarts = await _CartsRepository.UpdateAsync(Carts, cancellationToken);

        var result = _mapper.Map<UpdateCartsResult>(UpdatedCarts);

        return result;
    }
}
