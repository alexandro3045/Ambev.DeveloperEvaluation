using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Handler for processing GetCartsCommand requests
/// </summary>
public class GetProductHandler : IRequestHandler<GetCartsCommand, GetCartsResult>
{
    private readonly ICartsRepository _CartsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCartsCommand</param>
    public GetProductHandler(
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
    public async Task<GetCartsResult> Handle(GetCartsCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Carts = await _CartsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (Carts == null)
            throw new KeyNotFoundException($"Carts with ID {request.Id} not found");

        return _mapper.Map<GetCartsResult>(Carts);
    }
}
