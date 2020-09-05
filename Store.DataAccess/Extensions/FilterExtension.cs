using System;
using System.Linq;
using System.Linq.Expressions;
using static Store.Shared.Enums.Filter.Enums;

namespace Store.DataAccess.Extensions
{
    public static class FilterExtension
    {
        public const string OrderByCommand = "OrderBy";
        public const string OrderByDescendingCommand = "OrderByDescending";

        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, 
            string orderByProperty, string sortType)
        {
            string commandName = sortType == SortType.Descending.ToString() ? OrderByDescendingCommand : OrderByCommand;
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), commandName, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
