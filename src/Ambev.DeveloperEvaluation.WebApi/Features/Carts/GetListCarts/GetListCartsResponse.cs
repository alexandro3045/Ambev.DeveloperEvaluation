
namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;

/// <summary>
/// API response model for ListCartsOperation
/// </summary>
public class GetListCartsResponse
{
    /// <summary>
    /// The list Carts
    /// </summary>
    public List<Domain.Entities.Carts> ListCarts { get; set; }
}
