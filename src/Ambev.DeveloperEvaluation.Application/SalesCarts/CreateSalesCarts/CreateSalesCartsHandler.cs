using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;

/// <summary>
/// Handler for processing CreateSalesCartsCommand requests
/// </summary>
public class CreateSalesCartsHandler : IRequestHandler<CreateSalesCartsCommand, CreateSalesCartsResult>
{
    private readonly ISalesCartsRepository _SalesCartsRepository;
    private readonly IProductRepository _ProductsRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of CreateSalesCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="mediator">The mediator for CreateSalesCartsCommand</param>
    public CreateSalesCartsHandler(ISalesCartsRepository SalesCartsRepository, IProductRepository ProductsRepository
        , IMapper mapper, IMediator mediator)
    {
        _ProductsRepository = ProductsRepository;
        _SalesCartsRepository = SalesCartsRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the CreateSalesCartsCommand request
    /// </summary>
    /// <param name="command">The CreateCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Created Sales Carts details</returns>
    public async Task<CreateSalesCartsResult> Handle(CreateSalesCartsCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesCartsValidator();

        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var salesCarts = _mapper.Map<Domain.Entities.SalesCarts>(command);

        var products = salesCarts.Carts.CartsProductsItems.Select(x => x.ProductId).ToArray();

        if (products.Length == 0)
            throw new ValidationException("Products is required");

        if (products.Length > 0)
        {
            var itemsProducts = _ProductsRepository
                 .GetAllProductsByIdsAsync(products, cancellationToken)
                 .WaitAsync(cancellationToken)
                 .GetAwaiter().GetResult();

            if (itemsProducts != null)
            {
                itemsProducts?.ForEach(item =>
                {
                    if (item != null)
                    {
                        var Itemproducts = salesCarts.Carts.CartsProductsItems.Find(p => p.ProductId == item.Id);
                        if (Itemproducts != null)
                        {
                            Itemproducts.Product = item;
                        }
                    }
                });
            }
        }

        salesCarts.CalculateCart();

        var createdSalesCarts = await _SalesCartsRepository.CreateAsync(salesCarts, cancellationToken);

        var notification = _mapper.Map<BaseNotification>(createdSalesCarts);

        await _mediator.Publish(notification, cancellationToken);

        var result = _mapper.Map<CreateSalesCartsResult>(createdSalesCarts);

        return new CreateSalesCartsResult
            (
             createdSalesCarts.SalesNumber ?? 0,
             createdSalesCarts.CreatedAt,
             createdSalesCarts.UserId,
             createdSalesCarts.TotalSalesAmount,
             createdSalesCarts.BranchId,
             createdSalesCarts.Carts.CartsProductsItems.Select(p =>
                    new CartItemResult(p.CartId, p.ProductId, p.Quantity, p.TotalAmountItem,
                    p.UnitPrice, p.Discounts, p.Canceled)).ToList(),
             createdSalesCarts.Quantities,
             createdSalesCarts.Canceled,
             createdSalesCarts.CartId
            );
    }
}
