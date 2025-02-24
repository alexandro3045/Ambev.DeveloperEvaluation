using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for User entity operations
/// </summary>
public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

    Task<string[]> GetAllCategoriesAsync(CancellationToken cancellationToken = default);

    Task<List<Product>?> GetAllProductsByIdsAsync(Guid[] productsids, CancellationToken cancellationToken = default);

    Task<List<Product>?> GetByCategoryAsync(string category, int page, int size, string order, string direction, CancellationToken cancellationToken = default);

}
