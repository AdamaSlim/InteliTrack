using InteliTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Data;

public class AppDbContext : DbContext
{
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


        modelBuilder.Entity<Employee>()
            .ToTable("employees");

        modelBuilder.Entity<Role>()
            .ToTable("roles");

        modelBuilder.Entity<Store>()
            .ToTable("stores");

        modelBuilder.Entity<Product>()
            .ToTable("products");

        modelBuilder.Entity<Category>()
            .ToTable("categories");

        modelBuilder.Entity<Supplier>()
            .ToTable("suppliers");

        modelBuilder.Entity<Stock>()
            .ToTable("stocks");

        modelBuilder.Entity<Shelf>()
            .ToTable("shelves");

        modelBuilder.Entity<Section>()
            .ToTable("sections");

        modelBuilder.Entity<StockMovement>()
            .ToTable("stockmovements");

        modelBuilder.Entity<Transfer>()
            .ToTable("transfers");

        modelBuilder.Entity<TransferItem>()
            .ToTable("transferitems");


        // Employee mapping

        modelBuilder.Entity<Employee>()
            .Property(e => e.Id)
            .HasColumnName("id");

        modelBuilder.Entity<Employee>()
            .Property(e => e.StoreId)
            .HasColumnName("storeid");

        modelBuilder.Entity<Employee>()
            .Property(e => e.RoleId)
            .HasColumnName("roleid");

        modelBuilder.Entity<Employee>()
            .Property(e => e.IsActive)
            .HasColumnName("isactive");


        // Store mapping

        modelBuilder.Entity<Store>()
            .Property(s => s.Id)
            .HasColumnName("id");


        // Role mapping

        modelBuilder.Entity<Role>()
            .Property(r => r.Id)
            .HasColumnName("id");


        // Product mapping

        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .HasColumnName("id");


        // Stock mapping

        modelBuilder.Entity<Stock>()
            .Property(s => s.Id)
            .HasColumnName("id");


        // Shelf mapping

        modelBuilder.Entity<Shelf>()
            .Property(s => s.Id)
            .HasColumnName("id");


        // Section mapping

        modelBuilder.Entity<Section>()
            .Property(s => s.Id)
            .HasColumnName("id");


        // Transfer mapping

        modelBuilder.Entity<Transfer>()
            .Property(t => t.Id)
            .HasColumnName("id");


        // TransferItem mapping

        modelBuilder.Entity<TransferItem>()
            .Property(t => t.Id)
            .HasColumnName("id");


        // StockMovement mapping

        modelBuilder.Entity<StockMovement>()
            .Property(s => s.Id)
            .HasColumnName("id");
    }
}