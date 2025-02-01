using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCarts;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCarts feature
    /// </summary>
    public CreateCartsProfile()
    {
        CreateMap<CreateCartsRequest, CreateCartsCommand>();
        CreateMap<CreateCartsResult, CreateCartsResponse>();
    }
}
