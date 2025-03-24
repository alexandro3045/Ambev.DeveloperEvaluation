using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;

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
        CreateMap<Guid, DeleteProductsCommand>()
            .ConstructUsing(id => new DeleteProductsCommand(id));

        CreateMap<DeleteProductsResponse, DeleteProductResult>();
    }
}
