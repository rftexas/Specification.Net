using System.Linq.Expressions;

namespace Specification.Net
{

    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);

        Expression<Func<T, bool>> Expression { get; }
    }
}