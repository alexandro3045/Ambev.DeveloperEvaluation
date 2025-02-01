namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCarts;

/// <summary>
/// Request model for deleting a Carts
/// </summary>
public class DeleteCartsRequest
{
    /// <summary>
    /// The unique identifier of the Carts to delete
    /// </summary>
    public Guid Id { get; set; }
}
