using Ambev.DeveloperEvaluation.Application.Products.GetListProducts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Profile for mapping between Products entity and GetProductResult
/// </summary>
public class GetListProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListProducts operation
    /// </summary>
    public GetListProductsProfile()
    {
        CreateMap<List<Product>, GetListProductResult>()
            .ConstructUsing(listProduct => new GetListProductResult(listProduct)); 
    }
}
