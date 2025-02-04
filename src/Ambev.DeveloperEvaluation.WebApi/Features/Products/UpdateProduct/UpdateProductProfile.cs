using Ambev.DeveloperEvaluation.Application.Products.UpdateProducts;
using Ambev.DeveloperEvaluation.Application.Productss.UpdateProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Profile for mapping between Application and API UpdateProductresponses
/// </summary>
public class UpdateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateProduct feature
    /// </summary>
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductsCommand>();
        CreateMap<UpdateProductResult, UpdateProductResponse>();
    }
}
