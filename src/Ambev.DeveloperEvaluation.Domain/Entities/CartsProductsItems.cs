using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartsProductsItems : BaseEntity
    {
        public Guid CartId { get; set; }
        public virtual Carts Cart { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmountItem { get; set; }
        public decimal Discounts { get; set; }
        public bool Canceled { get; set; }
    }
}
