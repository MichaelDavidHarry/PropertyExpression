using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PropertyExpression
{
    internal static class MemberExpressionHelper
    {
        /// <summary>
        /// Gets a MemberInfo (ex. PropertyInfo or FieldInfo) extracted from the provided expression that selects a member.
        /// </summary>
        /// <typeparam name="T">The type the member exists on.</typeparam>
        /// <typeparam name="V">The type of the member's value.</typeparam>
        /// <typeparam name="MemberInfoType">Should be either System.Reflection.PropertyInfo or System.Reflection.FieldInfo.</typeparam>
        /// <param name="expression">An expression that selects a member.</param>
        /// <returns>The MemberType extracted from the expression.</returns>
        // Inspired by https://stackoverflow.com/a/17116267.
        public static MemberInfoType GetMemberInfo<T, V, MemberInfoType>(this Expression<Func<T, V>> expression)
            where MemberInfoType : MemberInfo
        {
            MemberExpression memberExpression = null;
            if (expression.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)expression.Body;
                if (unaryExpression.Operand is MemberExpression)
                {
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
            }
            else if (expression.Body is MemberExpression)
            {
                memberExpression = (MemberExpression)expression.Body;
            }

            if (memberExpression == null || !(memberExpression.Member is MemberInfoType))
            {
                throw new ArgumentException($"{nameof(expression)} does not refer to a valid {typeof(MemberInfoType).Name.Replace("Info", String.Empty).ToLower()}.");
            }

            return (MemberInfoType)memberExpression.Member;
        }
    }
}
