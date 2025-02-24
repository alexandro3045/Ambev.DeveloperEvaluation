
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;

/// <summary>
/// API response model for ListCartsOperation
/// </summary>
public class GetListCartsResponse
{
    public GetListCartsResponse(List<Domain.Entities.Carts> listCarts)
    {
        ListCarts = listCarts.Select(c => new CartsResponse
        {
            Id = c.Id,
            Date = c.CreatedAt,
            UserId = c.UserId,
            Products = c.CartsProductsItems?.Select(p => new ItemProduct(p.ProductId, p.Quantity)).ToList() ?? []
        }).ToList();
    }

    /// <summary>
    /// The list Carts
    /// </summary>
    public List<CartsResponse> ListCarts { get; set; }
}
