
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
    /// Gets or sets the unique identifier of the newly created ProductsItems.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created ProductsItems in the system.</value>
    public Guid Id { get; set; }

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
    public List<Domain.Entities.CartsProductsItems> Products { get; set; }
}
