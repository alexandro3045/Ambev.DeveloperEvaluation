using Ambev.DeveloperEvaluation.Common.Filter;
using Ambev.DeveloperEvaluation.Common.QueryExpression;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Common.DBExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Ambev.DeveloperEvaluation.Domain.Entities;

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
            _context.Entry<TEntity>(entity).State = EntityState.Modified;

            await _context.Set<TEntity>().AddOrUpdateAsync(entity);

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

        public async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

           return true;
        }

        public async Task<List<TEntity>> GetByPropertyValueAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> source = _context.Set<TEntity>()
            .AsQueryable();

            source = source.Where(filter);

            return await source
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> source = _context.Set<TEntity>()
            .IncludeAllRecursively()
            .AsQueryable();

            var filters = CustomExpressionFilter<TEntity>.CustomFilterColumn($"Id={id}", typeof(TEntity).Name);

            source = source.Where(filters);


            return await source
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> source = _context.Set<TEntity>()
            .IncludeAllRecursively()
            .AsQueryable();

            var filters = CustomExpressionFilter<TEntity>.CustomFilterColumn($"Id={id}", typeof(TEntity).Name);

            source = source.Where(filters);

            if (include != null)
            {
                source = include(source);
            }

            return await source
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetByFilterAsync(string? columnFilters, CancellationToken cancellationToken = default)
        {
            return await GetAllAsync(default, default, default, default, columnFilters, cancellationToken);
        }

        public async Task<List<TEntity>> GetAllAsync(int page, int size, string? order, string? direction,
            string? columnFilters, CancellationToken cancellationToken = default)
        {

            Expression<Func<TEntity, bool>> filters = null;

            IQueryable<TEntity> source = _context.Set<TEntity>()
                .IncludeAllRecursively(10)                
                .AsQueryable();


            if (!string.IsNullOrEmpty(columnFilters))
            {
                filters = CustomExpressionFilter<TEntity>.CustomFilterColumn(columnFilters, typeof(TEntity).Name);

                source = source.Where(filters);
            }

            if (page > 0 && size > 0)
            {
                source = source
               .Skip((page - 1) * size)
               .Take(size);
            }

            if (!string.IsNullOrEmpty(order) && !string.IsNullOrEmpty(direction))
            {
                source = source
                 .Skip((page - 1) * size)
                 .OrderBySource(order, direction);
            }

            return await source
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetAllAsync(int page, int size, string order, string direction, string? ColumnFilters, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, CancellationToken cancellationToken = default)
        {
            Expression<Func<TEntity, bool>> filters = null;

            IQueryable<TEntity> source = _context.Set<TEntity>()
                .IncludeAllRecursively(10)
                .AsQueryable();


            if (!string.IsNullOrEmpty(ColumnFilters))
            {
                filters = CustomExpressionFilter<TEntity>.CustomFilterColumn(ColumnFilters, typeof(TEntity).Name);

                source = source.Where(filters);
            }

            if (include != null)
            {
                source = include(source);
            }

            if (page > 0 && size > 0)
            {
                source = source
               .Skip((page - 1) * size)
               .Take(size);
            }

            if (!string.IsNullOrEmpty(order) && !string.IsNullOrEmpty(direction))
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
