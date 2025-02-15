using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Carts : BaseEntity
    {
        public Carts()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the date and time when the carts was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the UserId when the carts was created.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets the products when the carts was created.
        /// </summary>
        public List<CartsProductItem> CartsProductsItemns { get; set; }
    }
}
