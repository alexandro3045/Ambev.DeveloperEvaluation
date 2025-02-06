using Ambev.DeveloperEvaluation.Application.Users.GetListUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

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
        CreateMap<CreateCartsCommand, Domain.Entities.Carts>();
        CreateMap<Domain.Entities.Carts, CreateCartsResult>();
    }
}
