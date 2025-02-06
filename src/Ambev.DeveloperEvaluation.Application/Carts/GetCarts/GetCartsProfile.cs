using AutoMapper;

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
        CreateMap<Domain.Entities.Carts, GetCartsResult>();
    }
}
