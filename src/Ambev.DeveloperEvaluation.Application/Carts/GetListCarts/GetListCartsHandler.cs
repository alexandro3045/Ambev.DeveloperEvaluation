using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetListCarts;

/// <summary>
/// Handler for processing GetCartsCommand requests
/// </summary>
public class GetListCartsHandler : IRequestHandler<GetListCartsCommand, GetListCartsResult>
{
    protected readonly ICartsRepository _CartsRepository;
    protected readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetListCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCartsCommand</param>
    public GetListCartsHandler(
        ICartsRepository CartssRepository,
        IMapper mapper)
    {
        _CartsRepository = CartssRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetCartsCommand request
    /// </summary>
    /// <param name="request">The GetCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cartss details if found</returns>
    public virtual async Task<GetListCartsResult> Handle(GetListCartsCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetListCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var listCarts = await _CartsRepository.GetAllAsync(request.Page, request.Size, request.Order, request.Direction,
            request.ColumnFilters, cancellationToken);

        return _mapper.Map<GetListCartsResult>(listCarts);
    }
}
