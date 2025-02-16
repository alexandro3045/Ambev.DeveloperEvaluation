using System.Linq.Expressions;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Common.Filter
{
    public static class CustomExpressionFilter<T> where T : class
    {
        private static readonly MethodInfo ContainsMethod = typeof(string).GetMethod("Contains");
        private static readonly MethodInfo StartsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
        private static readonly MethodInfo EndsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
        public class ExpressionFilter
        {
            public string ColumnName { get; set; }
            public string Value { get; set; }
            public string Funcao { get; set; }
        }

        public static Expression<Func<T, bool>> CustomFilterColumn(string? filtersColumn, string className)
        {

            var filterColumn = new List<ColumnFilter>();
            if (!string.IsNullOrEmpty(filtersColumn))
            {
                filtersColumn.Split('&').ToList().ForEach(x =>
                {
                    if (x.Split('=')[0].Split("min").Length > 1)
                    {
                        filterColumn.Add(new ColumnFilter { Id = x.Split('=')[0].Split("min")[1], Value = x.Split('=')[1], Range = "Min" });
                    }
                    else if (x.Split('=')[0].Split("max").Length > 1)
                    {
                        filterColumn.Add(new ColumnFilter { Id = x.Split('=')[0].Split("max")[1], Value = x.Split('=')[1], Range = "Max" });
                    }
                    else if (x.Split('=')[1].Split("*").Length > 1)
                    {
                        filterColumn.Add(new ColumnFilter { Id = x.Split('=')[0], Value = x.Split('=')[1], Range = "Like" });
                    }
                    else
                    {
                        filterColumn.Add(new ColumnFilter { Id = x.Split('=')[0], Value = x.Split('=')[1] });
                    }
                });
            }
            return CustomFilter(filterColumn, className);
        }

        public static Expression<Func<T, bool>> CustomFilter(List<ColumnFilter> columnFilters, string className)
        {
            Expression<Func<T, bool>> filters = null;
            try
            {
                var expressionFilters = new List<ExpressionFilter>();
                foreach (var item in columnFilters)
                {
                    expressionFilters.Add(new ExpressionFilter() { ColumnName = item.Id, Value = item.Value , Funcao = item.Range });
                }
                // Create the parameter expression for the input data
                var parameter = Expression.Parameter(typeof(T), className);

                // Build the filter expression dynamically
                Expression filterExpression = null;
                foreach (var filter in expressionFilters)
                {
                    var startWith = filter.Value.StartsWith("*");
                    var endsWith = filter.Value.EndsWith("*");

                    if (startWith)
                        filter.Value = filter.Value.Remove(0, 1);

                    if (endsWith)
                        filter.Value = filter.Value.Remove(filter.Value.Length - 1, 1);

                    var property = Expression.Property(parameter, filter.ColumnName);

                    Expression comparison=null;

                    if (filter.Funcao == "Min")
                    {
                        var constant = Expression.Constant(decimal.Parse(filter.Value));
                        comparison = Expression.GreaterThanOrEqual(property, constant);
                    }
                    if (filter.Funcao == "Max")
                    {
                        var constant = Expression.Constant(decimal.Parse(filter.Value));
                        comparison = Expression.LessThanOrEqual(property, constant);
                    }
                    if (filter.Funcao == "Like")
                    {
                        var constant = Expression.Constant(filter.Value);

                        comparison = startWith ?
                            Expression.Call(property, "StartsWith", Type.EmptyTypes, constant) :
                             Expression.Call(property, "EndsWith", Type.EmptyTypes, constant);
                    }
                    if (property.Type == typeof(string) && string.IsNullOrEmpty(filter.Funcao))
                    {
                        var constant = Expression.Constant(filter.Value);
                        comparison = Expression.Call(property, "Contains", Type.EmptyTypes, constant);
                    }
                    else if (property.Type == typeof(double))
                    {
                        var constant = Expression.Constant(Convert.ToDouble(filter.Value));
                        comparison = Expression.Equal(property, constant);
                    }
                    else if (property.Type == typeof(Guid))
                    {
                        var constant = Expression.Constant(Guid.Parse(filter.Value));
                        comparison = Expression.Equal(property, constant);
                    }
                    else if (property.Type == typeof(Int32))
                    {
                        var constant = Expression.Constant(Convert.ToInt32(filter.Value));
                        comparison = Expression.Equal(property, constant);
                    }


                    filterExpression = filterExpression == null
                        ? comparison
                        : Expression.And(filterExpression, comparison);
                }

                // Create the lambda expression with the parameter and the filter expression
                filters = Expression.Lambda<Func<T, bool>>(filterExpression, parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                filters = null;
            }
            return filters;
        }

        public static Expression<Func<TSource, bool>> LikeExpression<TSource, TMember>(Expression<Func<TSource, TMember>> property, string value)
        {
            var param = Expression.Parameter(typeof(TSource), "t");
            var propertyInfo = GetPropertyInfo(property);
            var member = Expression.Property(param, propertyInfo.Name);

            var startWith = value.StartsWith("*");
            var endsWith = value.EndsWith("*");

            if (startWith)
                value = value.Remove(0, 1);

            if (endsWith)
                value = value.Remove(value.Length - 1, 1);

            var constant = Expression.Constant(value);
            Expression exp;

            if (endsWith && startWith)
            {
                exp = Expression.Call(member, ContainsMethod, constant);
            }
            else if (startWith)
            {
                exp = Expression.Call(member, EndsWithMethod, constant);
            }
            else if (endsWith)
            {
                exp = Expression.Call(member, StartsWithMethod, constant);
            }
            else
            {
                exp = Expression.Equal(member, constant);
            }

            return Expression.Lambda<Func<TSource, bool>>(exp, param);
        }

        private static PropertyInfo GetPropertyInfo(Expression expression)
        {
            var lambda = expression as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("expression");

            MemberExpression memberExpr = null;

            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpr = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
                    break;
                case ExpressionType.MemberAccess:
                    memberExpr = lambda.Body as MemberExpression;
                    break;
            }

            if (memberExpr == null)
                throw new InvalidOperationException("Specified expression is invalid. Unable to determine property info from expression.");


            var output = memberExpr.Member as PropertyInfo;

            if (output == null)
                throw new InvalidOperationException("Specified expression is invalid. Unable to determine property info from expression.");

            return output;
        }

    }
}
