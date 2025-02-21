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
                         join Products in _context.Products on ProductsItems.ProductId equals Products.Id
                         join Carts in _context.Carts on ProductsItems.CartId equals Carts.Id
                         where ProductsItems.CartId == cartId
                               select  new CartsProductsItems { 
                                   Product = Products,
                                   CartId = ProductsItems.CartId,
                                   ProductId = ProductsItems.ProductId,
                                   Quantity = ProductsItems.Quantity,
                                   Id = ProductsItems.Id,
                                   Cart = Carts
                               } ;

            result.Include(p => p.Product);

            return await result
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<CartsProductsItems>> GetByCartIdProducIdAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default)
        {
            var result = from CartsProductsItems in _context.CartsProductsItems
                         join Products in _context.Products on CartsProductsItems.ProductId equals Products.Id
                         join Carts in _context.Carts on CartsProductsItems.CartId equals Carts.Id
                         where CartsProductsItems.CartId == cartId && CartsProductsItems.ProductId == productId
                         select new CartsProductsItems
                         {
                             Product = Products,
                             CartId = CartsProductsItems.CartId,
                             ProductId = CartsProductsItems.ProductId,
                             Quantity = CartsProductsItems.Quantity,
                             Id = CartsProductsItems.Id,
                             Cart = Carts
                         };

            result.Include(p => p.Product);

            return await result
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
