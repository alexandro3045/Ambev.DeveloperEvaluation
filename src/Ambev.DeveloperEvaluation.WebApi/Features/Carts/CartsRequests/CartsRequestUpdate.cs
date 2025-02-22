namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

/// <summary>
/// Represents a request to create a new products in the system.
/// </summary>
public class CartsRequestUpdate
{
    /// <summary>
    /// Gets the Id when the carts was created/updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime Date { get; set; } =  DateTime.Now;

    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets the products when the carts was created.
    /// </summary>
    public List<ItemProductUpdate> Products { get; set; }
}

public class ItemProductUpdate : ItemProduct
{
    public ItemProductUpdate(Guid productId, int quantity, bool canceled) : base(productId, quantity)
    {
        Canceled = canceled;
    }
    public bool Canceled { get; set; }
}
