using System;
using System.Linq.Expressions;

namespace ClearBank.DeveloperTest.Specifications;

internal abstract class Specification<T>
{
    public Specification<T> And(Specification<T> specification) => new AndSpecification<T>(this, specification);
    public bool IsSatisfiedBy(T entity) => ToExpression().Compile()(entity);
    public abstract Expression<Func<T, bool>> ToExpression();
}

internal class AndSpecification<T> : Specification<T>
{
    private readonly Expression<Func<T, bool>> _left;
    private readonly Expression<Func<T, bool>> _right;

    public AndSpecification(
        Specification<T> left,
        Specification<T> right)
    {
        _left = left.ToExpression();
        _right = right.ToExpression();
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var andExpr = Expression.AndAlso(_left.Body, _right.Body);

        return Expression.Lambda<Func<T, bool>>(andExpr, _left.Parameters[0]);
    }
}