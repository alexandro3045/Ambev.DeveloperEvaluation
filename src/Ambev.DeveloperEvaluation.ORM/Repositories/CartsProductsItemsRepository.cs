using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartsProductsItemsRepository : Repository<CartsProductsItems>, ICartsProductsItemsRepository
    {
        public CartsProductsItemsRepository(DefaultContext context) : base(context) { }

        public async Task<List<CartsProductsItems>> GetByCartIdAsync(Guid cartId, CancellationToken cancellationToken = default)
        {
            var result = from ProductsItems in _context.CartsProductsItems
                               where ProductsItems.CartId == cartId
                               select  new CartsProductsItems { 
                                   Product = ProductsItems.Product,
                                   CartId = ProductsItems.CartId,
                                   ProductId = ProductsItems.ProductId,
                                   Quantity = ProductsItems.Quantity,
                                   Id = ProductsItems.Id,
                                   Cart = ProductsItems.Cart
                               } ;

            result.Include(x => x.Product);

            return await result
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
