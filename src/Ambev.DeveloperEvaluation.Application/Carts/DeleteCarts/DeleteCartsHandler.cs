using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCarts;

namespace Ambev.DeveloperEvaluation.Application.Cartss.DeleteCarts;

/// <summary>
/// Handler for processing DeleteCartsCommand requests
/// </summary>
public class DeleteCartsHandler : IRequestHandler<DeleteCartsCommand, DeleteCartsResponse>
{
    private readonly ICartsRepository _CartsRepository;

    /// <summary>
    /// Initializes a new instance of DeleteCartsHandler
    /// </summary>
    /// <param name="CartsRepository">The Carts repository</param>
    /// <param name="validator">The validator for DeleteCartsCommand</param>
    public DeleteCartsHandler(
        ICartsRepository CartsRepository)
    {
        _CartsRepository = CartsRepository;
    }

    /// <summary>
    /// Handles the DeleteCartsCommand request
    /// </summary>
    /// <param name="request">The DeleteCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteCartsResponse> Handle(DeleteCartsCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _CartsRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Carts with ID {request.Id} not found");

        return new DeleteCartsResponse { Success = true };
    }
}
