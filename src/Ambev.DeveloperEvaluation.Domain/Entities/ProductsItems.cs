
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class ProductsItems : BaseEntity
    {
        /// <summary>
        /// Gets the ProoductId from product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets the Quatity the from product
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the Product the from products
        /// </summary>
        public Product Product { get; set; }
    }
}
