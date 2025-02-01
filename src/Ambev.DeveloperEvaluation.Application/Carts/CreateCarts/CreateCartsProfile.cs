using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Profile for mapping between Carts entity and CreateCartsResponse
/// </summary>
public class CreateCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCarts operation
    /// </summary>
    public CreateCartsProfile()
    {
        CreateMap<CreateCartsCommand, Domain.Entities.Carts>().ReverseMap();
    }
}
