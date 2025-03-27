using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;

/// <summary>
/// Handler for processing GetCartsCommand requests
/// </summary>
public class GetListSalesCartsHandler : IRequestHandler<GetListSalesCartsCommand, GetListSalesCartsResult>
{
    protected readonly ISalesCartsRepository _SalesCartsRepository;
    protected readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetListSalesHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCartsCommand</param>
    public GetListSalesCartsHandler(
        ISalesCartsRepository SalesCartsRepository,
        IMapper mapper)
    {
        _SalesCartsRepository = SalesCartsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetCartsCommand request
    /// </summary>
    /// <param name="request">The GetCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cartss details if found</returns>
    public virtual async Task<GetListSalesCartsResult> Handle(GetListSalesCartsCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetListSalesCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var listCarts = await _SalesCartsRepository.GetAllAsync(request.Page, request.Size,
             request.Order, request.Direction, request.ColumnFilters, cancellationToken);

        return _mapper.Map<GetListSalesCartsResult>(listCarts);
    }
}
