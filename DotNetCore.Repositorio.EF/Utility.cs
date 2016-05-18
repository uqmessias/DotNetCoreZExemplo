using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNetCore.Repositorio.EF
{
    public static class Utility
    {
        //makes expression for specific prop
        public static Expression<Func<TSource, object>> GetExpression<TSource>(string propertyName, Type type)
        {
            var param = Expression.Parameter(typeof(TSource), "x");
            Expression conversion = Expression.Convert(Expression.Property
                (param, propertyName), type);   //important to use the Expression.Convert
            return Expression.Lambda<Func<TSource, object>>(conversion, param);
        }

        //makes deleget for specific prop
        public static Func<TSource, object> GetFunc<TSource>(string propertyName, Type t)
        {
            return GetExpression<TSource>(propertyName, t).Compile();  //only need compiled expression
        }

        //OrderBy overload
        public static IOrderedEnumerable<TSource>
            OrderBy<TSource>(this IEnumerable<TSource> source, string propertyName, Type t)
        {
            return source.OrderBy(GetFunc<TSource>(propertyName, t));
        }

        //OrderBy overload
        public static IOrderedQueryable<TSource>
            OrderBy<TSource>(this IQueryable<TSource> source, string propertyName, Type t)
        {
            return source.OrderBy(GetExpression<TSource>(propertyName, t));
        }

        public static string GetName(this LambdaExpression expression)
        {
            var member = (MemberExpression)expression.Body;
            return member.Member.Name;
        }

        public static IOrderedEnumerable<TSource> OrderByDescending<TSource>(this IEnumerable<TSource> source, string propertyName, Type t)
        {
            return source.OrderByDescending(GetFunc<TSource>(propertyName, t));
        }

        //OrderBy overload
        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> source, string propertyName, Type t)
        {
            return source.OrderByDescending(GetExpression<TSource>(propertyName, t));
        }

    }
}