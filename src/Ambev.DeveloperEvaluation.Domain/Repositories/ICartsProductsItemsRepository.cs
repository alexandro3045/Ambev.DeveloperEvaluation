using Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Repository interface for CartsProductsItems entity operations
/// </summary>
namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartsProductsItemsRepository : IRepository<CartsProductsItems>
    {

        Task<List<CartsProductsItems>> GetByCartIdAsync(Guid cartId, CancellationToken cancellationToken = default);

        Task<List<CartsProductsItems>> GetByCartIdProducIdAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default);
    }
}
