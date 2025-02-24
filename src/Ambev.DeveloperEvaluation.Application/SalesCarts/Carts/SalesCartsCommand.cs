using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;


namespace Ambev.DeveloperEvaluation.Application.SalesCarts.Carts
{
    public class SalesCartsCommand
    {
        /// <summary>
        /// Gets the SalesNumber sales when the carts was created.
        /// </summary>
        public required int SalesNumber { get; set; }

        /// <summary>
        /// Gets the branch sales when the carts was created.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets the cartID sales when the carts was created/updated.
        /// </summary>
        public Guid CartId { get; set; }

        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the UserId when the carts was created.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets the products when the carts was created.
        /// </summary>
        public List<CartItem> Products { get; set; }
    }
}
