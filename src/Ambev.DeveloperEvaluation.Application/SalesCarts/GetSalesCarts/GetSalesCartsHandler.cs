using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;

/// <summary>
/// Handler for processing GetSalesCartsCommand requests
/// </summary>
public class GetSalesCartsHandler : IRequestHandler<GetSalesCartsCommand, GetSalesCartsResult>
{
    private readonly ICartsRepository _CartsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCartsCommand</param>
    public GetSalesCartsHandler(
        ICartsRepository CartsRepository,
        IMapper mapper)
    {
        _CartsRepository = CartsRepository;
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

        var Carts = await _CartsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (Carts == null)
            throw new KeyNotFoundException($"SalesCarts with ID {request.Id} not found");

        return _mapper.Map<GetSalesCartsResult>(Carts);
    }
}
