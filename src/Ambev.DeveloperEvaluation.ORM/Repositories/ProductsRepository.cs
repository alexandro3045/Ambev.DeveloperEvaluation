using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductsRepository using Entity Framework Core
/// </summary>
public class ProductsRepository : Repository<Products>, IProductsRepository
{
    public ProductsRepository(DefaultContext context) : base(context) {  }

    public async Task<Products?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(u => u.Title == title, cancellationToken);
    }
}
