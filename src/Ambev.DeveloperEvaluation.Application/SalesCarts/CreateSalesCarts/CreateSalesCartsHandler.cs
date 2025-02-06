using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;

/// <summary>
/// Handler for processing CreateSalesCartsCommand requests
/// </summary>
public class CreateSalesCartsHandler : IRequestHandler<CreateSalesCartsCommand, CreateSalesCartsResult>
{
    private readonly ISalesCartsRepository _SalesCartsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSalesCartsHandler
    /// </summary>
    /// <param name="SalesCartsRepository">The Carts repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateCartsCommand</param>
    public CreateSalesCartsHandler(ISalesCartsRepository SalesCartsRepository, IMapper mapper)
    {
        _SalesCartsRepository = SalesCartsRepository;
        _mapper = mapper;
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
       
        var Carts = _mapper.Map<Domain.Entities.SalesCarts>(command);

        var CreatedCarts = await _SalesCartsRepository.CreateAsync(Carts, cancellationToken);
        var result = _mapper.Map<CreateSalesCartsResult>(CreatedCarts);
        return result;
    }
}
