namespace Specification.Net
{

    public static class SpecificationExtensions
    {
        public static Specification<T> And<T>(this Specification<T> left, Specification<T> right) =>
            left != null ? new AndSpecification<T>(left, right) : right;

        public static Specification<T> Or<T>(this Specification<T> left, Specification<T> right) =>
            left != null ? new OrSpecification<T>(left, right) : right;
    }
}