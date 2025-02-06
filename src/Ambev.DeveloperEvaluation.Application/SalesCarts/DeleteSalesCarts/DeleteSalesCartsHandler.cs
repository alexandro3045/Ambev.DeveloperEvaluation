using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.DeleteSalesCarts;

/// <summary>
/// Handler for processing DeleteSalesCartsCommand requests
/// </summary>
public class DeleteSalesCartsHandler : IRequestHandler<DeleteSalesCartsCommand, DeleteSalesCartsResponse>
{
    private readonly ISalesCartsRepository _SalesCartsRepository;

    /// <summary>
    /// Initializes a new instance of DeleteSalesCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The SalesCarts repository</param>
    /// <param name="validator">The validator for DeleteSalesCartsCommand</param>
    public DeleteSalesCartsHandler(
        ISalesCartsRepository SalesCartsRepository)
    {
        _SalesCartsRepository = SalesCartsRepository;
    }

    /// <summary>
    /// Handles the DeleteSalesCartsCommand request
    /// </summary>
    /// <param name="request">The DeleteSalesCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSalesCartsResponse> Handle(DeleteSalesCartsCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSalesCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _SalesCartsRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"SalesCarts with ID {request.Id} not found");

        return new DeleteSalesCartsResponse { Success = true };
    }
}
