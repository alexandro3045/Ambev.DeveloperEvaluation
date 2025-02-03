using Ambev.DeveloperEvaluation.Common.Filter;
using Ambev.DeveloperEvaluation.Common.QueryExpression;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Text.Json;


namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DefaultContext _context;
        public Repository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {

            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {

            _context.Set<TEntity>().Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public async Task<List<TEntity>> GetAllAsync(int page, int size, string order, string direction,
            string? columnFilters, string? searchTerm, CancellationToken cancellationToken = default)
        {
            var filterColumn = new List<ColumnFilter>() { new ColumnFilter { Id = columnFilters, Value = searchTerm } };

            Expression<Func<TEntity, bool>> filters = null;
            //First, we are checking our SearchTerm. If it contains information we are creating a filter.
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                filters = x => x.GetType().GetProperty("columnFilters").GetValue(x).ToString().ToLower().Contains(searchTerm);
            }
            // Then we are overwriting a filter if columnFilters has data.
            if (!columnFilters.IsNullOrEmpty() || !searchTerm.IsNullOrEmpty())
            {
                filters = CustomExpressionFilter<TEntity>.CustomFilter(filterColumn, typeof(TEntity).Name);

                return await _context.Set<TEntity>()
                .AsNoTracking()
                .Where(filters)
                .Skip((page - 1) * size)
                .Take(size)
                .OrderBySource(order, direction)
                .ToListAsync(cancellationToken);
            }

            return await _context.Set<TEntity>()
                .AsNoTracking()
                .Skip((page - 1) * size)
                .Take(size)
                .OrderBySource(order,direction)
                .ToListAsync(cancellationToken);
        }
    }
}
