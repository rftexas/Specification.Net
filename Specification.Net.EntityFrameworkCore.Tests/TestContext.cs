using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Specification.Net.EntityFrameworkCore.Tests.Models;

namespace Specification.Net.EntityFrameworkCore.Tests;

public class TestContext : DbContext
{
    private readonly SqliteConnection _conn;
    public DbSet<Store> Store { get; set; }
    public DbSet<InventoryItem> InventoryItem { get; set; }

    public TestContext()
    {
        _conn = new("Data Source=:memory:");
        _conn.Open();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlite(_conn));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryItem>(builder =>
        {
            builder.ToTable("InventoryItem");
            builder.HasKey(k => new { k.StoreId, k.Id });
            builder.HasOne(k => k.Store).WithMany(s => s.Inventory);
        });
        modelBuilder.Entity<Store>(builder =>
        {
            builder.ToTable("Store");
            builder.HasKey(k => k.StoreId);
        });
        //base.OnModelCreating(modelBuilder);
    }

    public override void Dispose()
    {
        _conn.Dispose();
    }
}