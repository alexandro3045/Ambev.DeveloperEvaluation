using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartsRepository : Repository<Carts>, ICartsRepository
    {
        public CartsRepository(DefaultContext context) : base(context) { }

        public new async Task<Carts> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(Id, p => p.Include(p => p.CartsProductsItems)
            .ThenInclude(c => c.Cart)
            .ThenInclude(c => c.CartsProductsItems).ThenInclude(p => p.Product), cancellationToken);
        }

        public new async Task<List<Carts>> GetAllAsync(int page, int size, string? order, string? direction,
            string? columnFilters, CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(page, size, order ?? string.Empty, direction ?? string.Empty, columnFilters, p => p.Include(p => p.CartsProductsItems)
            .ThenInclude(c => c.Cart)
            .ThenInclude(c => c.CartsProductsItems).ThenInclude(p => p.Product), cancellationToken);
        }
    }
}
