using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCarts;

/// <summary>
/// Represents the response returned after successfully creating a new Carts.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly update Carts,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateCartsResult : GetCartsResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created Carts.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created Carts in the system.</value>
    public Guid Id { get; set; }
}
