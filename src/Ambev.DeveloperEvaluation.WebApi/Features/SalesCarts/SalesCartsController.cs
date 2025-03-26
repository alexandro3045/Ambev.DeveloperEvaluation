using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.DeleteSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.GetListSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.GetSalesCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.UpdateSalesCarts;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.DeleteSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetListSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.GetSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;
using Ambev.DeveloperEvaluation.WebApi.SalesCarts.GetSalesCarts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts;

/// <summary>
/// Controller for managing Carts operations
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
    /// Creates a new Carts
    /// </summary>
    /// <param name="request">The Carts creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Carts details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesCartsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSalesCarts([FromBody] CreateSalesCartsRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(new ApiResponse
            {
                Success = false,
                Errors =
                validationResult.Errors.Select(err => new ValidationErrorDetail { Detail = err.ErrorMessage, Error = err.ErrorCode }).ToList()
            });

        var command = _mapper.Map<CreateSalesCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSalesCartsResponse>
            {
                Success = true,
                Message = "SaleCarts created successfully",
                Data = _mapper.Map<CreateSalesCartsResponse>(response)
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message, ErrorType = ex.GetType().Name });
        }
    }

    /// <summary>
    /// Update a Carts
    /// </summary>
    /// <param name="request">The Carts update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update Carts details</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSalesCartsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSalesCarts([FromBody] UpdateSalesCartsRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(new ApiResponse
            {
                Success = false,
                Errors =
                validationResult.Errors.Select(err => new ValidationErrorDetail { Detail = err.ErrorMessage, Error = err.ErrorCode }).ToList()
            });

        var command = _mapper.Map<UpdateSalesCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Updated(_mapper.Map<UpdateSalesCartsResponse>(response), "SaleCarts updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message, ErrorType = ex.GetType().Name });
        }
    }

    /// <summary>
    /// Retrieves a Carts by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Carts</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Carts details if found</returns>
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
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message, ErrorType = ex.GetType().Name });
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
    [HttpGet("{page},{size},{order},{direction}")]
    [ProducesResponseType(typeof(PaginatedList<GetListSalesCartsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetListSalesCarts([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? order = "CreatedAt", [FromQuery] string? direction = "asc",
          [FromQuery] string? columnFilters = default, CancellationToken cancellationToken = default)
    {
        var request = new GetListSalesCartsRequest { Page = page, Size = size, Order = order, Direction = direction, ColumnFilters = columnFilters };
        var validator = new GetListSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetListSalesCartsCommand>(request);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);
        
            var mappedResponse = _mapper.Map<GetListSalesCartsResponse>(response);
            
            return OkPaginated(new PaginatedList<CartsResponse>(mappedResponse.ListSalesCarts, mappedResponse.ListSalesCarts.Count, page, size));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { Success = false, Message = ex.Message, ErrorType = ex.GetType().Name });
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
    public async Task<IActionResult> DeleteSalesCarts([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSalesCartsRequest { Id = id };
        var validator = new DeleteSalesCartsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(new ApiResponse
            {
                Success = false,
                Errors = validationResult.Errors.Select(err => new ValidationErrorDetail { Detail = err.ErrorMessage, Error = err.ErrorCode }).ToList()
            });

        var command = _mapper.Map<DeleteSalesCartsCommand>(request.Id);

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
            return NotFound(new ApiResponse { Success = false, Message = ex.Message, ErrorType = ex.GetType().Name });
        }

    }
}
