using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCarts;

/// <summary>
/// Profile for mapping DeleteCarts feature requests to commands
/// </summary>
public class DeleteCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteCarts feature
    /// </summary>
    public DeleteCartsProfile()
    {
        CreateMap<Guid, Application.Carts.DeleteCarts.DeleteCartsCommand>()
            .ConstructUsing(id => new Application.Carts.DeleteCarts.DeleteCartsCommand(id));
    }
}
