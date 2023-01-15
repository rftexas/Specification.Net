using System.Linq.Expressions;
using LinqExpression = System.Linq.Expressions.Expression;

namespace Specification.Net;

public interface ISpecification<T>{
    bool IsSatisfied(T item);

    Expression<Func<T, bool>> Expression { get; }
}
