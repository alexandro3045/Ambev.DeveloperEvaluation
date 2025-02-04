using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCarts;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCarts;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetListCarts;
using Ambev.DeveloperEvaluation.WebApi.Carts.GetCarts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCards;
using Ambev.DeveloperEvaluation.WebApi.Carts.GetCarts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

/// <summary>
/// Controller for managing Carts operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CartsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CartsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CartsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Carts
    /// </summary>
    /// <param name="request">The Carts creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Carts details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCarts([FromBody] CreateCartsRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return CreatedAtRoute("GetCarts", new { id = response.Id }, _mapper.Map<CreateCartsResponse>(response));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
        }
    }

    /// <summary>
    /// Update a Carts
    /// </summary>
    /// <param name="request">The Carts update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update Carts details</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCarts([FromBody] UpdateCartsRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return CreatedAtRoute("GetCarts", new { id = response.Id }, _mapper.Map<UpdateCartsResponse>(response));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retrieves a Carts by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Carts</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Carts details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCarts([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCartsRequest { Id = id };
        var validator = new GetCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetCartsCommand>(request.Id);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(_mapper.Map<GetCartsResponse>(response));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
        }

    }

    /// <summary>
    /// Retrieves a list Carts by their page, size and order
    /// </summary>
    /// <param name="page">The page of list</param>
    /// <param name="size">The page of list</param>
    /// <param name="order">The page of list</param>
    /// <param name="direction">The page of list</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of Carts </returns>
    [HttpGet()]
    [ProducesResponseType(typeof(PaginatedList<Domain.Entities.Carts?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetListCarts([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? order = "Date", [FromQuery] string? direction = "asc",
          [FromQuery] string? columnFilters = default, CancellationToken cancellationToken = default)
    {
        var request = new GetListCartsRequest { Page = page, Size = size, Order = order, 
                  ColumnFilters = columnFilters, Direction = direction };

        var validator = new GetListCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetListCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return OkPaginated(new PaginatedList<Domain.Entities.Carts?>(response.ListCarts, response.ListCarts.Count, page, size));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a Carts by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Carts to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the Carts was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCarts([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteCartsRequest { Id = id };
        var validator = new DeleteCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteCartsCommand>(request.Id);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Carts deleted successfully"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
        }

    }
}
