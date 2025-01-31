using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Profile for mapping GetProducts feature requests to commands
/// </summary>
public class GetProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProducts feature
    /// </summary>
    public GetProductsProfile()
    {
        CreateMap<Guid, GetProductsCommand>()
            .ConstructUsing(id => new GetProductsCommand(id));
    }
}
