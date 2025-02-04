using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

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
        CreateMap<Domain.Entities.Carts, UpdateCartsResult>();
        CreateMap<Domain.Entities.Carts, CreateCartsResult>();
    }
}
