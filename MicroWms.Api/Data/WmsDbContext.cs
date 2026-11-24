using Microsoft.EntityFrameworkCore;
using MicroWms.Domain.Entities;

namespace MicroWms.Api.Data;

public class WmsDbContext : DbContext
{
    public WmsDbContext(DbContextOptions<WmsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<StorageLocation> StorageLocations => Set<StorageLocation>();

    public DbSet<Box> Boxes => Set<Box>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderLine> OrderLines => Set<OrderLine>();

    public DbSet<Parcel> Parcels => Set<Parcel>();

    public DbSet<ParcelLine> ParcelLines => Set<ParcelLine>();

    public DbSet<SorterOutput> SorterOutputs => Set<SorterOutput>();

    public DbSet<WarehouseTask> WarehouseTasks => Set<WarehouseTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasIndex(x => x.Article)
            .IsUnique();

        modelBuilder.Entity<StorageLocation>()
            .HasIndex(x => x.Code)
            .IsUnique();

        modelBuilder.Entity<Box>()
            .HasIndex(x => x.Code)
            .IsUnique();

        modelBuilder.Entity<Order>()
            .HasIndex(x => x.Number)
            .IsUnique();

        modelBuilder.Entity<Parcel>()
            .HasIndex(x => x.Code)
            .IsUnique();

        modelBuilder.Entity<SorterOutput>()
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}

