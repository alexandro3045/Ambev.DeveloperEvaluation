namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

/// <summary>
/// Represents a request to create a new products in the system.
/// </summary>
public class CartsRequest
{
    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } =  DateTime.Now;

    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets the products when the carts was created.
    /// </summary>
    public required List<ItemProduct> Products { get; set; }
}

public class ItemProduct
{
    public ItemProduct(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

public class ItemProductResult : ItemProduct
{
    public ItemProductResult(Guid productId, int quantity, decimal unitPrice) : base(productId, quantity)
    {
        UnitPrice = unitPrice;
    }
    public ItemProductResult(Guid productId, int quantity, decimal totalAmountItem, decimal unitPrice) : base(productId, quantity)
    {
        TotalAmountItem = totalAmountItem;
        UnitPrice = unitPrice;
    }
    public decimal TotalAmountItem { get; set; }
    public decimal UnitPrice { get; set; }
}
