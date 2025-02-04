namespace Ambev.DeveloperEvaluation.Application.Carts.GetListCarts;

/// <summary>
/// Response model for GetCarts operation
/// </summary>
public class GetListCartsResult
{
    /// <summary>
    /// Gets list from carts
    /// </summary>
    public List<Domain.Entities.Carts> ListCarts { get; set; }

    public GetListCartsResult(List<Domain.Entities.Carts>? listCarts)
    {
        ListCarts = listCarts;
    }
}
