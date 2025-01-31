using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.GetListCategories;
using Ambev.DeveloperEvaluation.Application.Products.GetListCategorias;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetListCategories;

/// <summary>
/// Handler for processing GetCategoriesCommand requests
/// </summary>
public class GetListCategoriesHandler : IRequestHandler<GetListCategoriesCommand, GetListCategoriesResult>
{
    private readonly IProductsRepository _ProductsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetListCategoriesHandler
    /// </summary>
    /// <param name="CategoriesRepository">The Categories repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCategoriesCommand</param>
    public GetListCategoriesHandler(
        IProductsRepository ProductsRepository,
        IMapper mapper)
    {
        _ProductsRepository = ProductsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetCategoriesCommand request
    /// </summary>
    /// <param name="request">The GetCategories command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Categories details if found</returns>
    public async Task<GetListCategoriesResult> Handle(GetListCategoriesCommand request, CancellationToken cancellationToken)
    {
        var listCategories = await _ProductsRepository.GetAllCategoriesAsync(cancellationToken);

        return _mapper.Map<GetListCategoriesResult>(listCategories);
    }
}
