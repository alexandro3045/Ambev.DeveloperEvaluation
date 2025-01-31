using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for User entity operations
/// </summary>
public interface IProductsRepository : IRepository<Products>
{
    Task<Products?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
}
