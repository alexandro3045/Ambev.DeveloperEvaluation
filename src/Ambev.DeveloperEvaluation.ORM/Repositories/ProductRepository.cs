using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(DefaultContext context) : base(context) {  }

    public async Task<string[]> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products.Select(r => r.Category).Distinct().ToArrayAsync(cancellationToken);
    }

    public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(u => u.Title == title, cancellationToken);
    }

    public async Task<List<Product>?> GetAllProductsByIdsAsync(Guid[] productsids, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(r => productsids.Contains(r.Id)).ToListAsync(cancellationToken);
    }

    public async Task<List<Product>?> GetByCategoryAsync(string category, int page, int size, string order, string direction, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(u => u.Category == category).ToListAsync(cancellationToken);
    }
}
