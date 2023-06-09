namespace Specification.Net.EntityFrameworkCore.Tests.Models;

public class InventoryItem
{
    public int Id { get; }
    public string Name { get; }
    public int Count { get; }
    public int StoreId { get; }
    public Store Store { get; }

    public InventoryItem(int id, string name, int count, Store store)
    {
        Id = id;
        Name = name;
        Count = count;
        Store = store;
    }

    private InventoryItem() { }
    public InventoryItem Stock(int count) => new(Id, Name, Count + count, Store);
    public InventoryItem Sell(int count) => new(Id, Name, Count - count, Store);
}