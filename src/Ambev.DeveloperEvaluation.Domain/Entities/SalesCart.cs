using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

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
        public int? SalesNumber { get; set; }

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
        public int? Quantities { get; set; }

        /// <summary>
        /// Gets the canceled item products when the carts was created.
        /// </summary>
        public bool Canceled { get; set; }

        public void CalculateCart()
        {
            var group = Carts.CartsProductsItems.GroupBy(x => x.ProductId).Select(g=>
            {
                var item = g.FirstOrDefault();
                int Quantities = CalculteQuantity(item);
                decimal UnitPrice = item.UnitPrice;

                decimal TotalAmountItem, TotalSales, Discounts;
                CalculateReturn(item.Canceled, Quantities, UnitPrice, out TotalAmountItem, out TotalSales, out Discounts);

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

                static int CalculteQuantity(CartsProductsItems? item)
                => item != null && item.Quantity > 20 ? 20 : item.Quantity ;               

                static void CalculateReturn(bool canceled,int Quantities, decimal UnitPrice, out decimal TotalAmountItem, out decimal TotalSales, out decimal Discounts)
                {
                    TotalAmountItem = UnitPrice * Quantities;
                    TotalSales = CalculateTotalSales(canceled, Quantities, UnitPrice);
                    Discounts = CalculateDiscounts(Quantities, TotalSales);

                    static decimal CalculateTotalSales(bool canceled, int Quantities, decimal UnitPrice)
                                          =>  canceled ? 0 : Quantities <= 20 ? UnitPrice * Quantities : 0;

                    static decimal CalculateDiscounts(int Quantities, decimal TotalSales)
                      => Quantities >= 4 && Quantities < 10 ? (TotalSales / 100 * 10)
                                                            : Quantities >= 10 && Quantities <= 20 ? (TotalSales / 100 * 20) : 0;
                    
                }
            });

            group.ToList().ForEach(Product =>
            {
                Carts.CartsProductsItems.FindAll(p => p.ProductId == Product.Chave).ForEach(item =>
                     {
                         item.TotalAmountItem = Product.TotalAmountItem;
                         item.Quantity = Product.Quantities;
                         item.UnitPrice = Product.UnitPrice;
                         item.Discounts = Product.Discounts;
                     });
            });

            Quantities = Carts.CartsProductsItems.Count;
            TotalSalesAmount = group.ToList().Sum(g => g.TotalSales);
        }

        /// <summary>
        /// Performs validation of the user entity using the UserValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Username format and length</list>
        /// <list type="bullet">Email format</list>
        /// <list type="bullet">Phone number format</list>
        /// <list type="bullet">Password complexity requirements</list>
        /// <list type="bullet">Role validity</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SalesCartsValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}