using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetListCarts;

/// <summary>
/// Profile for mapping between Carts entity and GetCartsResult
/// </summary>
public class GetListCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListCarts operation
    /// </summary>
    public GetListCartsProfile()
    {
        CreateMap<List<Domain.Entities.Carts>, GetListCartsResult>()
            .ConstructUsing(listCarts => new GetListCartsResult(listCarts)); 
    }
}
