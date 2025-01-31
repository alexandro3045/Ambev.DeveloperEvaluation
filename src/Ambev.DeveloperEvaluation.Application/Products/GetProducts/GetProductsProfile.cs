using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Productss.GetProducts;

/// <summary>
/// Profile for mapping between Products entity and GetProductsResponse
/// </summary>
public class GetProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProducts operation
    /// </summary>
    public GetProductsProfile()
    {
        CreateMap<Domain.Entities.Product, GetProductsResult>();
    }
}
