using Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Products;

public class CreateProductsrRequestProfile : Profile
{
    public CreateProductsrRequestProfile()
    {
        CreateMap<CreateProductRequest, CreateProductsCommand>();
    }
}