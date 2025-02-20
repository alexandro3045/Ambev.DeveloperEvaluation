using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Handler for processing UpdateSalesCartsCommand requests
/// </summary>
public class UpdateCartsHandler : IRequestHandler<UpdateSalesCartsCommand, UpdateSalesCartsResult>
{
    private readonly ISalesCartsRepository _SalesCartsRepository;
    private readonly IProductsRepository _ProductsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartsCommand</param>
    public UpdateCartsHandler(ISalesCartsRepository SalesCartsRepository, IProductsRepository ProductsRepository,
        IMapper mapper)
    {
        _ProductsRepository = ProductsRepository;
        _SalesCartsRepository = SalesCartsRepository;
        _mapper = mapper;
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

        var products = salesCarts.Carts.CartsProductsItems.Select(x => x.ProductId).ToArray();

        if (products.Length == 0)
            throw new ValidationException("Products is required");

        if (products.Length > 0)
        {
            _ProductsRepository
                .GetAllProductsByIdsAsync(products, cancellationToken)
                .WaitAsync(cancellationToken)
                .GetAwaiter().GetResult().ForEach(item =>
                {
                    salesCarts.Carts.CartsProductsItems.Find(p => p.ProductId == item.Id).Product = item;
                });
        }

        salesCarts.CalculateCart();

        var UpdatedCarts = await _SalesCartsRepository.UpdateAsync(salesCarts, cancellationToken);
        var result = _mapper.Map<UpdateSalesCartsResult>(UpdatedCarts);
        return result;
    }
}
