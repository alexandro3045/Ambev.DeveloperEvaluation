using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProducts;
using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;


namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Profile for mapping between Carts entity and UpdateCartsResponse
/// </summary>
public class UpdateCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCarts operation
    /// </summary>
    public UpdateCartsProfile()
    {
        CreateMap<UpdateCartsCommand, Domain.Entities.Carts>();
        CreateMap<Domain.Entities.Carts, UpdateProductResult>();
        CreateMap<Domain.Entities.Carts, CreateProductsResult>();
    }
}
