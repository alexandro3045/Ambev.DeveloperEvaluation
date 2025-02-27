using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Profile for mapping between Product entity and CreateProductResponse
/// </summary>
public class CreateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProduct operation
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<Product, BaseNotification>()
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().Name))
         .ForMember(dest => dest.Action, opt => opt.MapFrom(src => ActionNotification.Created));

        CreateMap<CreateProductsCommand, Product>();
        CreateMap<Product, CreateProductsResult>();
    }
}
