using Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCards;

/// <summary>
/// Profile for mapping between Application and API UpdateCartsResponse
/// </summary>
public class UpdateCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCards feature
    /// </summary>
    public UpdateCartsProfile()
    {
        CreateMap<UpdateCartsRequest, UpdateCartsCommand>();
        CreateMap<UpdateCartsResult, UpdateCartsResponse>();
    }
}

