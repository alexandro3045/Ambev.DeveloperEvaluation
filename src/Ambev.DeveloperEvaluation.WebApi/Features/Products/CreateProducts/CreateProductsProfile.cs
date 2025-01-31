using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProducts feature
    /// </summary>
    public CreateProductsProfile()
    {
        CreateMap<CreateProductsRequest, CreateProductsCommand>();
        CreateMap<CreateProductsResult, CreateProductsResponse>();
    }
}
