using Specification.Net.EntityFrameworkCore.Tests.Models;

namespace Specification.Net.EntityFrameworkCore.Tests;

public class ExtensionTests : IDisposable
{
    private readonly TestContext _context = new();

    public ExtensionTests()
    {
        _context.Database.EnsureCreated();
        var store = new Store { StoreId = 1, Name = "Jersey" };
        store.Inventory.Add(new InventoryItem(1, "Item", 1, store));
        store.Inventory.Add(new InventoryItem(2, "Another Name", 10, store));
        _context.Store.Add(store);
        _context.SaveChanges();


    }

    [Fact]
    public void Single_specification()
    {

        var item = _context.InventoryItem.FirstOrDefault(new LookupSpecification(1));
        Assert.Equal(1, item.Id);
    }

    [Fact]
    public void Chained_specification()
    {
        var items = _context.InventoryItem.Where(new LookupSpecification(1).Or(new LookupSpecification(2)));
        Assert.NotEmpty(items);
        Assert.Equal(2, items.Count());
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

public class LookupSpecification : Specification<InventoryItem>
{
    public LookupSpecification(int id) : base(it => it.Id == id) { }
}