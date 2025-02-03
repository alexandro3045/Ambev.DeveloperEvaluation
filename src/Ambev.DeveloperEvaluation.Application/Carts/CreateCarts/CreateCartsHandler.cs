using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;


namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

/// <summary>
/// Handler for processing CreateCartsCommand requests
/// </summary>
public class CreateCartsHandler : IRequestHandler<CreateCartsCommand, CreateCartsResult>
{
    private readonly ICartsRepository _CartsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateCartsCommand</param>
    public CreateCartsHandler(ICartsRepository CartsRepository, IMapper mapper)
    {
        _CartsRepository = CartsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateCartsCommand request
    /// </summary>
    /// <param name="command">The CreateCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Carts details</returns>
    public async Task<CreateCartsResult> Handle(CreateCartsCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartsCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Carts = _mapper.Map<Domain.Entities.Carts>(command);

        var createdCarts = await _CartsRepository.CreateAsync(Carts, cancellationToken);
        var result = _mapper.Map<CreateCartsResult>(createdCarts);
        return result;
    }
}
