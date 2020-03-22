using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PropertyExpression
{
    public static class FieldInfoExpressionExtensions
    {
        /// <summary>
        /// Gets a FieldInfo extracted from the provided expression that selects a field.
        /// </summary>
        /// <typeparam name="T">The type the field exists on.</typeparam>
        /// <typeparam name="V">The type of the field's value.</typeparam>
        /// <param name="expression">An expression that selects a field.</param>
        /// <returns>The FieldInfo extracted from the expression.</returns>
        public static FieldInfo GetFieldInfo<T, V>(this Expression<Func<T, V>> expression)
        {
            return MemberExpressionHelper.GetMemberInfo<T, V, FieldInfo>(expression);
        }
    }
}
