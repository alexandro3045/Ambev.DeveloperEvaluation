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
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartsCommand</param>
    public UpdateCartsHandler(ISalesCartsRepository SalesCartsRepository, IMapper mapper)
    {
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
       
        var Carts = _mapper.Map<Domain.Entities.SalesCarts>(command);

        var UpdatedCarts = await _SalesCartsRepository.UpdateAsync(Carts, cancellationToken);
        var result = _mapper.Map<UpdateSalesCartsResult>(UpdatedCarts);
        return result;
    }
}
