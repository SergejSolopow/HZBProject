using System.Linq.Expressions;
using System.Reflection;

namespace BeamlineX.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<TSource>(this Expression<Func<TSource, object>> propertyLambda)
        {
            return propertyLambda.GetPropertyInfo().Name;
        }

        public static PropertyInfo GetPropertyInfo<TSource>(this Func<TSource, object> func)
        {
            return Expression.Lambda<Func<TSource, object>>(Expression.Call(func.Method)).GetPropertyInfo();
        }

        public static PropertyInfo GetPropertyInfo<TSource, TProperty>(this Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            Expression operand = propertyLambda?.Body ?? throw new ArgumentNullException(nameof(propertyLambda), "Parameter darf nicht NULL sein");
            while (operand.NodeType == ExpressionType.TypeAs || operand.NodeType == ExpressionType.Convert || operand.NodeType == ExpressionType.ConvertChecked)
            {
                operand = ((UnaryExpression)operand).Operand;
            }

            if (operand is not MemberExpression member)
            {
                throw new ArgumentException($"Expression '{ propertyLambda }' refers to a method, not a property.");
            }

            PropertyInfo? propInfo = member.Member as PropertyInfo ?? throw new ArgumentException($"Expression '{ propertyLambda }' refers to a field, not a property.");
    
            if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
            {
                throw new ArgumentException($"Expression '{ propertyLambda }' refers to a property that is not from type {type}.");
            }

            return propInfo;
        }

        public static Action<TEntity, TValue> GetSetter<TEntity, TValue>(this Expression<Func<TEntity, TValue>> expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            ParameterExpression newValue = Expression.Parameter(expression.Body.Type);
            Expression<Action<TEntity, TValue>> assign = Expression.Lambda<Action<TEntity, TValue>>(Expression.Assign(expression.Body, newValue), expression.Parameters[0], newValue);

            return assign.Compile();
        }

        public static Func<TEntity, TValue> GetGetter<TEntity, TValue>(this Expression<Func<TEntity, TValue>> expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return expression.Compile();
        }
    }
}
