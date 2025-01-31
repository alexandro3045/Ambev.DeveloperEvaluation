using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Common.QueryExpression
{
    public static class QueryFunctions
    {
        public static IQueryable<TEntity> OrderBySource<TEntity>(this IQueryable<TEntity> source, string order, string direction) where TEntity : class
        {
            IQueryable<TEntity> returnValue = null;


            Expression resultExpression = source.Expression;

            string strAsc = "OrderBy";
            string strDesc = "OrderByDescending";


            string propertyName = order;
            string orderNarrow = direction;

            string command = orderNarrow.ToUpper().Contains("DESC") ? strDesc : strAsc;

            Type type = typeof(TEntity);
            ParameterExpression parameter = Expression.Parameter(type, "p");

            System.Reflection.PropertyInfo property;
            Expression propertyAccess;

            if (propertyName.Contains('.'))
            {
                // support to be sorted on child fields. 
                String[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);

                for (int i = 1; i < childProperties.Length; i++)
                {
                    Type t = property.PropertyType;
                    if (!t.IsGenericType)
                    {
                        property = t.GetProperty(childProperties[i]);
                    }
                    else
                    {
                        property = t.GetGenericArguments().First().GetProperty(childProperties[i]);
                    }

                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = type.GetProperty(propertyName);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }

            if (property.PropertyType == typeof(object))
            {
                propertyAccess = Expression.Call(propertyAccess, "ToString", null);
            }

            LambdaExpression orderByExpression = Expression.Lambda(propertyAccess, parameter);

            resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType == typeof(object) ? typeof(string) : property.PropertyType },
                resultExpression, Expression.Quote(orderByExpression));


            returnValue = source.Provider.CreateQuery<TEntity>(resultExpression);

            return returnValue;
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<T>(propertyName));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }
    }
}
