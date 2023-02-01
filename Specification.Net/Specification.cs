using System.Linq.Expressions;

namespace Specification.Net
{

    public abstract class Specification<T> : ISpecification<T>
    {
        protected readonly Func<T, bool> CompiledExpression;
        protected Specification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
            CompiledExpression = expression.Compile();
        }
        public Expression<Func<T, bool>> Expression { get; protected set; }

        public bool IsSatisfied(T item)
        {
            return CompiledExpression(item);
        }

        public static ISpecification<T> Not(ISpecification<T> spec) => new NotSpecification<T>(spec);
    }
}