using System;
using System.Linq.Expressions;
using System.Reflection;

namespace PropertyExpression
{
    public static class PropertyInfoExpressionExtensions
    {
        /// <summary>
        /// Gets a PropertyInfo extracted from the provided expression that selects a property.
        /// </summary>
        /// <typeparam name="T">The type the property exists on.</typeparam>
        /// <typeparam name="V">The type of the property's value.</typeparam>
        /// <param name="expression">An expression that selects a property.</param>
        /// <returns>The PropertyInfo extracted from the expression.</returns>
        public static PropertyInfo GetPropertyInfo<T, V>(this Expression<Func<T, V>> expression)
        {
            return MemberExpressionHelper.GetMemberInfo<T, V, PropertyInfo>(expression);
        }
    }
}
