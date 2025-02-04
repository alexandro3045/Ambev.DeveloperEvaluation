using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Profile for mapping between Carts entity and GetCartsResponse
/// </summary>
public class GetCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCarts operation
    /// </summary>
    public GetCartsProfile()
    {
        CreateMap<Product, GetCartsResult>();
    }
}
