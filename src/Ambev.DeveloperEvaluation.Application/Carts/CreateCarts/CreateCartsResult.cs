using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;

/// <summary>
/// Represents the response returned after successfully creating a new Carts.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Carts,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateCartsResult
{
    /// <summary>
    /// Gets the UserId from user
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets the date from carts
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the List from product.
    /// </summary>
    public List<Product> Carts { get; set; }
}
