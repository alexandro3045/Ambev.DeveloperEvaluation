using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SalesCartsRepository : Repository<SalesCarts>, ISalesCartsRepository
    {
        public SalesCartsRepository(DefaultContext context) : base(context) { }

        public new async Task<SalesCarts> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(Id, p => p.Include(c => c.Carts)
            .ThenInclude(c => c.CartsProductsItems).ThenInclude(p => p.Product), cancellationToken);
        }

        public new async Task<List<SalesCarts>> GetAllAsync(int page, int size, string? order, string? direction,
            string? columnFilters, CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(page, size, order ?? string.Empty, direction ?? string.Empty, columnFilters, p => p.Include(p => p.Carts)
            .ThenInclude(c => c.CartsProductsItems).ThenInclude(p => p.Product), cancellationToken);
        }

    }
}
