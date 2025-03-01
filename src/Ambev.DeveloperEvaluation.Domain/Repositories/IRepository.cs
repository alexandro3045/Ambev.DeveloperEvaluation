using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for entity operations
/// </summary>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Creates a new entity in the repository
    /// </summary>
    /// <param name="TEntity">The TEntity to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created entity</returns>
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a new entity in the repository
    /// </summary>
    /// <param name="TEntity">The TEntity to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update entity</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a entity from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the entity was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a entity from the repository
    /// </summary>
    /// <param name="TEntity">The TEntity to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the entity was deleted, false if not found</returns>
    Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a entity by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a entity by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <param name="IIncludableQueryable">Include debset</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<TEntity> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a entity by their unique identifier
    /// </summary>
    /// <param name="ColumnFilters">Columns filters list of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<List<TEntity>> GetByFilterAsync(string? columnFilters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all entity
    /// </summary>
    /// <param name="page">Page of pagination to list of the entity</param>
    /// <param name="size">Size of pagination to list of the entity</param>
    /// <param name="order">Order of pagination to list of the entity</param>
    /// <param name="ColumnFilters">Columns filters list of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<List<TEntity>> GetAllAsync(int page, int size, string order, string direction, string? ColumnFilters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all entity
    /// </summary>
    /// <param name="page">Page of pagination to list of the entity</param>
    /// <param name="size">Size of pagination to list of the entity</param>
    /// <param name="order">Order of pagination to list of the entity</param>
    /// <param name="ColumnFilters">Columns filters list of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <param name="IIncludableQueryable">Include debset</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<List<TEntity>> GetAllAsync(int page, int size, string order, string direction, string? ColumnFilters, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all entity
    /// </summary>
    /// <param name="propertie">propertie filter of to list of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<List<TEntity>> GetByPropertyValueAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
}
