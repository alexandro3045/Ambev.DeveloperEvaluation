using Microsoft.IdentityModel.Tokens;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

/// <summary>
/// Represents a request to create a new products in the system.
/// </summary>
public class CartsRequest
{

    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime Date { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets the products when the carts was created.
    /// </summary>
    private List<ItemProduct> products;
    public List<ItemProduct> Products
    {
        get
        {
            return !products.IsNullOrEmpty() ? [.. products.OrderBy(p => p.ProductId)] : products;
        }
        set
        {
            products = value;
        }
    }
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
    public bool Canceled { get; set; }

    public override bool Equals(object obj)
    {
        return ProductId == ((ItemProduct)obj).ProductId &&
          Quantity == ((ItemProduct)obj).Quantity &&
          Canceled == ((ItemProduct)obj).Canceled;
    }
}

public class ItemProductResult : ItemProduct
{

    public ItemProductResult(Guid productId, int quantity, decimal unitPrice, bool canceled) : base(productId, quantity)
    {
        UnitPrice = unitPrice;
        Canceled = canceled;
    }

    public ItemProductResult(Guid productId, int quantity, decimal totalAmountItem, decimal unitPrice, bool canceled) : base(productId, quantity)
    {
        TotalAmountItem = totalAmountItem;
        UnitPrice = unitPrice;
        Canceled = canceled;
    }

    public ItemProductResult(Guid productId, int quantity, decimal totalAmountItem, decimal unitPrice, bool canceled, decimal discounts) : base(productId, quantity)
    {
        TotalAmountItem = totalAmountItem;
        UnitPrice = unitPrice;
        Discounts = discounts;
        Canceled = canceled;
    }

    public decimal TotalAmountItem { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discounts { get; set; }
}
