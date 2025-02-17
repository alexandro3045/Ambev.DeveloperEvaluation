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
        public int SaleNumber { get; set; }

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
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets the Customer when the carts was created.
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// Gets the total sales when the carts was created.
        /// </summary>
        public decimal TotalSales { get; set; }

        /// <summary>
        /// Gets the branch sales when the carts was created.
        /// </summary>
        public Branch Branch { get; set; }

        /// <summary>
        /// Gets the Carts when the SalsesCarts was created.
        /// </summary>
        public Carts Carts { get; set; }

        /// <summary>
        /// Gets the quantities products when the carts was created.
        /// </summary>
        public int Quantities { get; set; }

        /// <summary>
        /// Gets the unit price products when the carts was created.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets the Discounts products when the carts was created.
        /// </summary>
        public decimal Discounts { get; set; }

        /// <summary>
        /// Gets the Total amount item products when the carts was created.
        /// </summary>
        public decimal TotalAmountItem { get; set; }

        /// <summary>
        /// Gets the canceled item products when the carts was created.
        /// </summary>
        public bool Canceled { get; set; }

        public void CalculateCart()
        {            
            Quantities = Carts.CartsProductsItemns.Count();

            var group = Carts.CartsProductsItemns.GroupBy(x => x.ProductId).Select(g => new
            {
                Chave = g.Key,
                Itens = g.ToList(),
                TotalAmountItem = g.Count(),
                Quantities = g.Count() > 20 ? 0 : g.Count(),
                TotalSales = TotalAmountItem <= 20 ? g.ToList().Sum(x => x.Product.Price) * g.Count() : 0,
                Discount = TotalAmountItem >= 4 ? TotalSales / (1 + 10)
                : TotalAmountItem >= 10 && TotalAmountItem <= 20 ? TotalSales / (1 + 20) : 0
            });
            
            Quantities = group.ToList().Sum(g => g.Quantities);
            TotalSales = group.ToList().Sum(g => g.TotalSales);
            Discounts = group.ToList().Sum(x => x.Discount);            
        }
    }
}