using LinqExpression = System.Linq.Expressions.Expression;

namespace Specification.Net;

public class OrSpecification<T> : Specification<T>
{
    public OrSpecification(ISpecification<T> left, ISpecification<T> right) : base(
        LinqExpression.Lambda<Func<T, bool>>(
            LinqExpression.OrElse(
                left.Expression.Body, 
                ReferenceEquals(left.Expression.Parameters.First(), right.Expression.Parameters.First()) 
                    ? right.Expression.Body 
                    : LinqExpression.Invoke(right.Expression, left.Expression.Parameters.First())), left.Expression.Parameters.First())
    )
    {
    }
}
