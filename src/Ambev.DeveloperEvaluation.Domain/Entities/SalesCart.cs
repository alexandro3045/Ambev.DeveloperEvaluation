using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SalesCarts : BaseEntity
    {
        public SalesCarts()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the sale number when the carts was created.
        /// </summary>
        public int SalesNumber { get; set; }

        /// <summary>
        /// Gets the date and time when the carts was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time when the carts was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets the Customer when the carts was created.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets the Customer when the carts was created.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets the total sales when the carts was created.
        /// </summary>
        public decimal TotalSalesAmount { get; set; }

        /// <summary>
        /// Gets the branch idsales when the carts was created.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets the branch sales when the carts was created.
        /// </summary>
        public Branch Branch { get; set; }

        /// <summary>
        /// Gets the CartId when the saleCarts was created.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets the Carts when the SalsesCarts was created.
        /// </summary>
        public Carts Carts { get; set; } = new();

        /// <summary>
        /// Gets the quantities products when the carts was created.
        /// </summary>
        public int Quantities { get; set; }

        /// <summary>
        /// Gets the canceled item products when the carts was created.
        /// </summary>
        public bool Canceled { get; set; }

        public void CalculateCart()
        {

            var group = Carts.CartsProductsItems.GroupBy(x => x.ProductId).Select(g=>
            {
                int Quantities = g.ToList().Sum(x => x.Quantity) > 20 ? 0 : g.ToList().Sum(x => x.Quantity);
                decimal TotalAmountItem = g.ToList().Sum(x => x.Product.Price) * Quantities;
                decimal TotalSales = Quantities <= 20 ? g.ToList().Sum(x => x.Product.Price) * Quantities : 0;
                decimal Discounts = Quantities >= 4 && Quantities < 10 ? (TotalSales / 100 * 10)
                                : Quantities >= 10 && Quantities <= 20 ? (TotalSales / 100 * 20) : 0;
                decimal UnitPrice = g.ToList().Sum(x => x.Product.Price);

                return new
                {
                    Chave = g.Key,
                    Itens = g.ToList(),
                    Quantities,
                    TotalAmountItem,
                    TotalSales,
                    Discounts,
                    UnitPrice
                };
            });

            group.ToList().ForEach(Product =>
            {
               var item =  Carts.CartsProductsItems.Find(p => p.ProductId == Product.Chave);
                item.TotalAmountItem = Product.TotalAmountItem;
                item.Quantity = Product.Quantities;
                item.UnitPrice = Product.UnitPrice;
                item.Discounts = Product.Discounts;
            });

            Quantities = Carts.CartsProductsItems.Count;
            TotalSalesAmount = group.ToList().Sum(g => g.TotalSales);
        }
    }
}