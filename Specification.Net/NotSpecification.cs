using LinqExpression = System.Linq.Expressions.Expression;

namespace Specification.Net
{

    public class NotSpecification<T> : Specification<T>
    {
        public NotSpecification(ISpecification<T> left) : base(
            LinqExpression.Lambda<Func<T, bool>>(
                LinqExpression.Not(
                    LinqExpression.Invoke(left.Expression, left.Expression.Parameters.First())), left.Expression.Parameters.First())
        )
        {
        }
    }
}