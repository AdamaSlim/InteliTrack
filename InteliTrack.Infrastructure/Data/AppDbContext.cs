using InteliTrack.Domain.Entities;
using InteliTrack.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InteliTrack.Infrastructure.Data;

public class AppDbContext : DbContext
{
    private static readonly ValueConverter<DateTime, DateTime> UtcDateTimeConverter =
        new(
            value => value.Kind == DateTimeKind.Utc ? value : DateTime.SpecifyKind(value, DateTimeKind.Utc),
            value => DateTime.SpecifyKind(value, DateTimeKind.Utc));

    private static readonly ValueConverter<DateTime?, DateTime?> NullableUtcDateTimeConverter =
        new(
            value => value.HasValue
                ? (value.Value.Kind == DateTimeKind.Utc ? value : DateTime.SpecifyKind(value.Value, DateTimeKind.Utc))
                : value,
            value => value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : value);

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


    public DbSet<Store> Stores => Set<Store>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Shelf> Shelves => Set<Shelf>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();
    public DbSet<Transfer> Transfers => Set<Transfer>();
    public DbSet<TransferItem> TransferItems => Set<TransferItem>();
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.PasswordHash)
                .HasColumnName("passwordhash")
                .HasColumnType("text")
                .IsRequired();
        });

        modelBuilder.Entity<Transfer>()
            .Property(t => t.Status)
            .HasConversion<string>()
            .HasColumnName("status");

        modelBuilder.Entity<StockMovement>()
            .Property(sm => sm.MovementType)
            .HasConversion<string>()
            .HasColumnName("movementtype");

        modelBuilder.Entity<Store>().HasQueryFilter(s => s.IsActive);
        modelBuilder.Entity<Category>().HasQueryFilter(c => c.IsActive);
        modelBuilder.Entity<Supplier>().HasQueryFilter(s => s.IsActive);
        modelBuilder.Entity<Product>().HasQueryFilter(p => p.IsActive);
        modelBuilder.Entity<Section>().HasQueryFilter(s => s.IsActive);
        modelBuilder.Entity<Shelf>().HasQueryFilter(s => s.IsActive);
        modelBuilder.Entity<Employee>().HasQueryFilter(e => e.IsActive);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()!.ToLower());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLower());

                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(UtcDateTimeConverter);
                }
                else if (property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(NullableUtcDateTimeConverter);
                }
            }

            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName()?.ToLower());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName()?.ToLower());
            }
        }
    }
}