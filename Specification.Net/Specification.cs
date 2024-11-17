using System.Linq.Expressions;

namespace Specification.Net
{

    public abstract class Specification<T>
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

        public static Specification<T> Not(Specification<T> spec) => new NotSpecification<T>(spec);
    }
}