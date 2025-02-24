using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Unit.Application.SalesCarts;

/// <summary>
/// Profile for mapping between Carts entity and CreateCartsResponse
/// </summary>
public class CreateSalesCartstHandlerTestsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCarts operation
    /// </summary>
    public CreateSalesCartstHandlerTestsProfile()
    {
        CreateMap<CartsProductsItems, DeveloperEvaluation.Domain.Entities.Product>()
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => new DateTime()))
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.UnitPrice));

        ;
    }
}
