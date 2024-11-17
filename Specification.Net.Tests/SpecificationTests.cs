namespace Specification.Net.Tests;

public class SpecificationTests
{
    class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class IsIdSpecification(int id) : Specification<TestEntity>(t => t.Id == id)
    {
    }

    class IsNameSpecification(string name) : Specification<TestEntity>(t => t.Name.Equals(name))
    {
    }

    [Fact]
    public void IsSatisfied_works_correctly()
    {
        var specification = new IsIdSpecification(1);

        var entity = new TestEntity { Id = 5, Name = "Smithe" };

        specification.IsSatisfied(entity).Should().BeFalse();

        specification.IsSatisfied(new TestEntity { Id = 1 }).Should().BeTrue();
    }

    [Fact]
    public void And_combines_correctly()
    {
        var specification = new IsIdSpecification(5).And(new IsNameSpecification("Smithe"));

        var entity = new TestEntity { Id = 5, Name = "smith" };

        specification.IsSatisfied(entity).Should().BeFalse();

        entity.Name = "Smithe";

        specification.IsSatisfied(entity).Should().BeTrue();
    }

    [Fact]
    public void Or_Combines_correctly()
    {
        var specification = new IsIdSpecification(1).Or(new IsIdSpecification(5));

        var entity = new TestEntity { Id = 3 };

        specification.IsSatisfied(entity).Should().BeFalse();

        entity.Id = 1;

        specification.IsSatisfied(entity).Should().BeTrue();

        entity.Id = 5;

        specification.IsSatisfied(entity).Should().BeTrue();
    }

    [Fact]
    public void Not_negates()
    {
        var specification = Specification<TestEntity>.Not(new IsIdSpecification(1));

        var entity = new TestEntity { Id = 3 };

        specification.IsSatisfied(entity).Should().BeTrue();
        entity.Id = 1;

        specification.IsSatisfied(entity).Should().BeFalse();

    }
}