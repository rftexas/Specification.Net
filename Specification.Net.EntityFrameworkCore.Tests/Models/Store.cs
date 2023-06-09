using System.Collections.ObjectModel;

namespace Specification.Net.EntityFrameworkCore.Tests.Models;

public class Store
{
    public int StoreId { get; set; }
    public string Name { get; set; }
    public Collection<InventoryItem> Inventory { get; set; } = new();
}