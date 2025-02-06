using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.DeleteSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.DeleteSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.SalesCarts.GetSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts;

/// <summary>
/// Controller for managing SalesCarts operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesCartsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SalesCartsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesCartsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new SalesCarts
    /// </summary>
    /// <param name="request">The SalesCarts creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created SalesCarts details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesCartsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSalesCarts([FromBody] CreateSalesCartsRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSalesCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return CreatedAtRoute("GetSalesCarts", new { id = response.Id }, _mapper.Map<CreateSalesCartsResponse>(response));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
        }
    }

    /// <summary>
    /// Update a SalesCarts
    /// </summary>
    /// <param name="request">The SalesCarts update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update SalesCarts details</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSalesCartsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSalesCarts([FromBody] UpdateSalesCartsRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateSalesCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return CreatedAtRoute("GetSalesCarts", new { id = response.Id }, _mapper.Map<UpdateSalesCartsResponse>(response));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retrieves a SalesCarts by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the SalesCarts</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The SalesCarts details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSalesCartsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSalesCarts([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSalesCartsRequest { Id = id };
        var validator = new GetSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSalesCartsCommand>(request.Id);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(_mapper.Map<GetSalesCartsResponse>(response));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
        }

    }

    /// <summary>
    /// Retrieves a list SalesCarts by their page, size and order
    /// </summary>
    /// <param name="page">The page of list</param>
    /// <param name="size">The page of list</param>
    /// <param name="order">The page of list</param>
    /// <param name="direction">The page of list</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of SalesCarts </returns>
    [HttpGet()]
    [ProducesResponseType(typeof(PaginatedList<Domain.Entities.SalesCarts?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetListSalesCarts([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? order = "Date", [FromQuery] string? direction = "asc",
          [FromQuery] string? columnFilters = default, CancellationToken cancellationToken = default)
    {
        var request = new GetListSalesCartsRequest { Page = page, Size = size, Order = order, 
                  ColumnFilters = columnFilters, Direction = direction };

        var validator = new GetListSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetListSalesCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return OkPaginated(new PaginatedList<Domain.Entities.SalesCarts?>(response.ListSalesCarts, response.ListSalesCarts.Count, page, size));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a SalesCarts by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the SalesCarts to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the SalesCarts was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSalesCarts([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSalesCartsRequest { Id = id };
        var validator = new DeleteSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSalesCartsCommand>(request.Id);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "SalesCarts deleted successfully"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
        }

    }
}
