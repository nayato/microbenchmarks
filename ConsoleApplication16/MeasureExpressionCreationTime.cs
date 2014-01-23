namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Microsoft.WindowsAzure.Storage.Table;
    using Wintellect;

    class MeasureExpressionCreationTime
    {
        public static long Run()
        {
            long ran = 0;
            const int iterations = 1000000;

            const string TransactionRowKeyPrefix = "__tx";

            var queryExpressionParameter = Expression.Parameter(typeof(DynamicTableEntity));
            var partitionKeyPropertyExpression = Expression.Property(
                queryExpressionParameter,
                typeof(DynamicTableEntity).GetProperty(GetPropertyName<DynamicTableEntity>(x => x.PartitionKey)));
            var rowKeyPropertyAccess = Expression.Property(
                queryExpressionParameter,
                typeof(DynamicTableEntity).GetProperty(GetPropertyName<DynamicTableEntity>(x => x.RowKey)));
            var stringCompareToMethodInfo = typeof(string).GetMethod("CompareTo", new[] {typeof(string)});
            var filterTransactionRowsExpression = Expression.And(
                Expression.GreaterThan(
                    Expression.Call(rowKeyPropertyAccess, stringCompareToMethodInfo, Expression.Constant(TransactionRowKeyPrefix)),
                    Expression.Constant(0)),
                Expression.LessThan(
                    Expression.Call(rowKeyPropertyAccess, stringCompareToMethodInfo, Expression.Constant(TransactionRowKeyPrefix + ":")),
                    Expression.Constant(0)));

            Func<string, IEnumerable<string>, Expression<Func<DynamicTableEntity, bool>>> composeTargetedReadFilterEx =
                (partitionKey, rowKeys) =>
                {
                    Expression eqFilter = null;
                    foreach (var rowKey in rowKeys)
                    {
                        var currentExpression = Expression.Equal(rowKeyPropertyAccess, Expression.Constant(rowKey));
                        eqFilter = eqFilter == null ? currentExpression : Expression.Or(eqFilter, currentExpression);
                    }

                    var result =
                        Expression.And(
                            Expression.Equal(
                                partitionKeyPropertyExpression,
                                Expression.Constant(partitionKey)),
                            Expression.Or(
                                eqFilter,
                                filterTransactionRowsExpression));
                    return Expression.Lambda<Func<DynamicTableEntity, bool>>(result, queryExpressionParameter);
                };

            CodeTimer.Time(true, "prebuilt", iterations, () =>
            {
                var exp = composeTargetedReadFilterEx("a", new[] {"1", "2"});
                if (exp.Body != null)
                    ran++;
            });

            CodeTimer.Time(true, "rebuilt", iterations, () => { ran = EvaluateRebuilt(TransactionRowKeyPrefix, ran); });

            return ran;
        }

        static long EvaluateRebuilt(string TransactionRowKeyPrefix, long ran)
        {
            var queryExpressionParameter = Expression.Parameter(typeof(DynamicTableEntity));
            var partitionKeyPropertyExpression = Expression.Property(
                queryExpressionParameter,
                typeof(DynamicTableEntity).GetProperty(GetPropertyName<DynamicTableEntity>(x => x.PartitionKey)));
            var rowKeyPropertyAccess = Expression.Property(
                queryExpressionParameter,
                typeof(DynamicTableEntity).GetProperty(GetPropertyName<DynamicTableEntity>(x => x.RowKey)));
            var stringCompareToMethodInfo = typeof(string).GetMethod("CompareTo", new[] {typeof(string)});
            var filterTransactionRowsExpression = Expression.And(
                Expression.GreaterThan(
                    Expression.Call(rowKeyPropertyAccess, stringCompareToMethodInfo, Expression.Constant(TransactionRowKeyPrefix)),
                    Expression.Constant(0)),
                Expression.LessThan(
                    Expression.Call(rowKeyPropertyAccess, stringCompareToMethodInfo, Expression.Constant(TransactionRowKeyPrefix + ":")),
                    Expression.Constant(0)));

            Expression eqFilter = null;
            foreach (var rowKey in new[] {"1", "2"})
            {
                var currentExpression = Expression.Equal(rowKeyPropertyAccess, Expression.Constant(rowKey));
                eqFilter = eqFilter == null ? currentExpression : Expression.Or(eqFilter, currentExpression);
            }

            var result =
                Expression.And(
                    Expression.Equal(
                        partitionKeyPropertyExpression,
                        Expression.Constant("a")),
                    Expression.Or(
                        eqFilter,
                        filterTransactionRowsExpression));
            var exp = Expression.Lambda<Func<DynamicTableEntity, bool>>(result, queryExpressionParameter);
            if (exp.Body != null)
                ran++;
            return ran;
        }

        public static string GetPropertyName<T>(Expression<Func<T, object>> pathExpression)
        {
            return GetMemberName(pathExpression.Body);
        }

        static string GetMemberName(Expression pathExpression)
        {
            var memberExpression = pathExpression as MemberExpression;
            if (memberExpression != null)
            {
                if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
                    return GetMemberName(memberExpression.Expression) + "." + memberExpression.Member.Name;
                return memberExpression.Member.Name;
            }
            var unaryExpression = pathExpression as UnaryExpression;
            if (unaryExpression != null)
            {
                if (unaryExpression.NodeType != ExpressionType.Convert)
                    throw new Exception(string.Format("Cannot interpret member from {0}", unaryExpression));
                return GetMemberName(unaryExpression.Operand);
            }
            throw new Exception(string.Format("Could not determine member from {0}", pathExpression));
        }
    }
}