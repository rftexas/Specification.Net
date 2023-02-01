namespace Specification.Net
{

    public static class SpecificationExtensions
    {
        public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right) =>
            left != null ? new AndSpecification<T>(left, right) : right;

        public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right) =>
            left != null ? new OrSpecification<T>(left, right) : right;
    }
}