using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductsRepository using Entity Framework Core
/// </summary>
public class ProductsRepository : Repository<Product>, IProductsRepository
{
    public ProductsRepository(DefaultContext context) : base(context) {  }

    public async Task<string[]> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products.Select(r => r.Category).ToArrayAsync(cancellationToken);
    }

    public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(u => u.Title == title, cancellationToken);
    }


}
