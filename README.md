# Specification.Net
A dotnet implementation of the Specification pattern.

##  Use Case

The specification pattern outlines a business rule that is combinable with other business rules. In this pattern, a unit of business logic inherits its functionality from the an abstract composite Specification class has one function called IsSatisfiedBy that returns a boolean value. After instantiation, the specification is "chained" with other specifications, making new specifications easily maintainable, yet highly customizable business logic.

As a consequence of performing runtime composition of high-level business/domain logic, the Specification pattern is a convenient tool for converting ad-hoc user search criteria into low level logic to be processed by repositories.

Since a specification is an encapsulation of logic in a reusable form it is very simple to thoroughly unit test, and when used in this context is also an implementation of the humble object pattern

## This Library
This version of the Specification was built with the intent of allowing developers to use the Specifications in Memory and against a Database through EntityFrameworkCore.

### A Simple Example
Given a simple Entity 
```Csharp
public record TestEntity(int Id, string Name, int Count) {
    public TestEntity IncrementCount(){
        return new TestEntity(Id, Name, Count + 1);
    }
};

//Check if the Id Matches our expectation.
public class MatchesIdSpecification: Specification<TestEntity>{
    MatchesIdSpecification(int testId) :base((te) => te.Id == testId) { }
}

//Check if the Name matches.
public class MatchesNameSpecification: Specification<TestEntity> {
    MatchesNameSpecification(string name): base(t => t.Name.Equals(name)) { }
}

//Check if the Count is negative
public class CountNegativeSpecification: Specification<TestEntity> {
    CountNegativeSpecification(): base (t => t.Count < 0) { }
}

```
With these Specifications we can check for Uniqueness and Correctness for our TestEntities. So what does that look like:

```csharp
Collection<TestEntity> entities = new();
entities.Add(new TestEntity(1, "First", 1));
entities.Add(new TestEntity(2, "Second", 0));
entities.Add(new TestEntity(3, "Third", -1));

bool AddEntity(int id, string name) {
    var findEntitySpecification = new MatchesIdSpecification(id)
            .Or(new MatchesNameSpecification(name));
    // This will find the first Entity that matches either by Id or by Name.
    var entity = entities.FirstOrDefault(findEntitySpecification.Satisfies);
    if(entity != null) {
        entity = entity.Increment();
    }
    else{
        entities.Add(new Entity(id, name, 1));
    }
}
```