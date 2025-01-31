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
        CreateMap<CreateProductRequest, CreateProductsCommand>();
        CreateMap<string, byte[]>().ConvertUsing(s => System.Convert.FromBase64String(s));
        CreateMap<byte[], string>().ConvertUsing(bytes => System.Convert.ToBase64String(bytes));
        CreateMap<CreateProductsResult, CreateProductsResponse>()
          .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image)).ReverseMap();
    }
}
