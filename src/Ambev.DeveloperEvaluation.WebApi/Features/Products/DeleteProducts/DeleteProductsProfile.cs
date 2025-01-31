using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;

/// <summary>
/// Profile for mapping DeleteProductsfeature requests to commands
/// </summary>
public class DeleteProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProducts feature
    /// </summary>
    public DeleteProductsProfile()
    {
        CreateMap<Guid, Application.Products.DeleteProducts.DeleteProductsCommand>()
            .ConstructUsing(id => new Application.Products.DeleteProducts.DeleteProductsCommand(id));
    }
}
