using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Collections.Internals;

internal static class ExpressionEx
{
    public static BinaryExpression Assign(Expression left, Expression right)
    {
        var assign = typeof(Assigner<>).MakeGenericType(left.Type).GetMethod("Assign");

        var assignExpr = Expression.Add(left, right, assign);

        return assignExpr;
    }

    private static class Assigner<T>
    {
        public static T Assign(ref T left, T right)
        {
            return (left = right);
        }
    }

    private static void InvokeAll(Action[] actions)
    {
        foreach (var action in actions)
            action();
    }

    public static Expression Block(params Expression[] expressions)
    {
        var invokeMethod = typeof(ExpressionEx).GetMethod("InvokeAll",
            BindingFlags.Static | BindingFlags.NonPublic);
        var actions = expressions.Select(e => Expression.Lambda<Action>(e))
            .ToArray();
        var arrayOfActions = Expression.NewArrayInit(typeof(Action), actions);
        return Expression.Call(invokeMethod, arrayOfActions);
    }
}