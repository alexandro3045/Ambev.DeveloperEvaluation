using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;

/// <summary>
/// Handler for processing GetSalesCartsCommand requests
/// </summary>
public class GetSalesCartsHandler : IRequestHandler<GetSalesCartsCommand, GetSalesCartsResult>
{
    private readonly ISalesCartsRepository _SalesCartsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The SalesCartsRepository repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCartsCommand</param>
    public GetSalesCartsHandler(
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
    /// <returns>The Carts details if found</returns>
    public async Task<GetSalesCartsResult> Handle(GetSalesCartsCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSalesCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var salesCarts = await _SalesCartsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (salesCarts == null)
            throw new KeyNotFoundException($"SalesCarts with ID {request.Id} not found");

        return _mapper.Map<GetSalesCartsResult>(salesCarts);
    }
}
