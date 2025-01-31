using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for User entity operations
/// </summary>
public interface IProductsRepository : IRepository<Product>
{
    Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

    Task<string[]> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
}
