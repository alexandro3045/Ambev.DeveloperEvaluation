using Ambev.DeveloperEvaluation.Common.Filter;
using Ambev.DeveloperEvaluation.Common.QueryExpression;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            string? columnFilters, CancellationToken cancellationToken = default)
        {
            var filterColumn = new List<ColumnFilter>();
            if (!string.IsNullOrEmpty(columnFilters))
            {
                columnFilters.Split('&').ToList().ForEach(x =>
                {
                    switch (x.Split('=')[0])
                    {
                        case "_minPrice":
                            filterColumn.Add(new ColumnFilter { Id = "Price", Value = x.Split('=')[1], Range = "Min" });
                            break;

                        case "_maxPrice":
                            filterColumn.Add(new ColumnFilter { Id = "Price", Value = x.Split('=')[1], Range = "Max" });
                            break;
                        default:
                            filterColumn.Add(new ColumnFilter { Id = x.Split('=')[0], Value = x.Split('=')[1] });
                            break;
                    }   
                });                
            }

            Expression<Func<TEntity, bool>> filters = null;

            IQueryable<TEntity> source = _context.Set<TEntity>().AsQueryable();
            // Then we are overwriting a filter if columnFilters has data.
            if (!string.IsNullOrEmpty(columnFilters))
            {
                filters = CustomExpressionFilter<TEntity>.CustomFilter(filterColumn, typeof(TEntity).Name);

                source = source.Where(filters);
            }

            if (page > 0 && size > 0)
            {
                source = source
               .Skip((page - 1) * size)
               .Take(size);
            }

            if (!string.IsNullOrEmpty(order))
            {
                source = source
                 .Skip((page - 1) * size)
                 .OrderBySource(order, direction);
            }

            return await source
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
