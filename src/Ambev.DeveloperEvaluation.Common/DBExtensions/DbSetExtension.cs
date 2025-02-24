using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Common.DBExtensions
{
    public static class DbSetExtension
    {
        /// <exception cref="ArgumentNullException"></exception>
        public static TEntity FindEntity<TEntity>(this DbSet<TEntity> dbSet, TEntity entity, bool noTracking = false) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var dbContext = dbSet.GetService<ICurrentDbContext>().Context;
            var entityEntry = dbContext.Entry(entity);
            var entityType = entityEntry.Metadata;
            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null)
            {
                return (noTracking ? dbSet.AsNoTracking() : dbSet).FirstOrDefault(item => item.Equals(entity));
            }

            var ids = primaryKey.Properties.Select(item => item.PropertyInfo.GetValue(entity)).ToArray();
            var result = dbSet.Find(ids);
            if (noTracking && result != null)
            {
                dbContext.Entry(result).State = EntityState.Detached;
            }

            return result;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public static async ValueTask<TEntity> FindEntityAsync<TEntity>(this DbSet<TEntity> dbSet, TEntity entity, bool noTracking = false)
            where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var dbContext = dbSet.GetService<ICurrentDbContext>().Context;
            var entityEntry = dbContext.Entry(entity);
            var entityType = entityEntry.Metadata;
            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null)
            {
                return await (noTracking ? dbSet.AsNoTracking() : dbSet).FirstOrDefaultAsync(item => item.Equals(entity));
            }

            var ids = primaryKey.Properties.Select(item => item.PropertyInfo.GetValue(entity)).ToArray();
            var result = await dbSet.FindAsync(ids);
            if (noTracking && result != null)
            {
                dbContext.Entry(result).State = EntityState.Detached;
            }

            return result;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public static EntityEntry<TEntity> Update<TEntity>(this DbSet<TEntity> dbSet, TEntity entity, bool? includeOrExclude = null,
            params string[] propertyNames) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entityEntry = dbSet.Update(entity);
            if (includeOrExclude != null)
            {
                foreach (var property in entityEntry.Properties)
                {
                    if (includeOrExclude.Value ^ propertyNames?.Contains(property.Metadata.PropertyInfo.Name) == true)
                    {
                        property.IsModified = false;
                    }
                }
            }

            return entityEntry;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public static EntityEntry<TEntity> AddOrUpdate<TEntity>(this DbSet<TEntity> dbSet, TEntity entity, bool? includeOrExclude = null,
            params string[] propertyNames) where TEntity : class
        {
            if (dbSet.FindEntity(entity, true) == null)
            {
                return dbSet.Add(entity);
            }

            return dbSet.Update(entity, includeOrExclude, propertyNames);
        }

        /// <exception cref="ArgumentNullException"></exception>
        public static async ValueTask<EntityEntry<TEntity>> AddOrUpdateAsync<TEntity>(this DbSet<TEntity> dbSet, TEntity entity, bool? includeOrExclude = null,
            params string[] propertyNames) where TEntity : class
        {
            if (await dbSet.FindEntityAsync(entity, true) == null)
            {
                return await dbSet.AddAsync(entity);
            }

            return dbSet.Update(entity, includeOrExclude, propertyNames);
        }

        public static IQueryable<TEntity> GetAllLazyLoad<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children) where TEntity : class
        {
            children.ToList().ForEach(x => dbSet.Include(x).Load());

            return dbSet;
        }
    }
}
