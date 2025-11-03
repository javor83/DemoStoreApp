using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestoreApp.LocalDbStore;

public partial class SportsStoreContext : DbContext
{
    public SportsStoreContext()
    {
    }

    public SportsStoreContext(DbContextOptions<SportsStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPreview> ProductPreviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORY__3214EC27A22EA291");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cname)
                .HasMaxLength(100)
                .HasColumnName("CNAME");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCTS__3214EC2739E1A12E");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Pcategory).HasColumnName("PCATEGORY");
            entity.Property(e => e.Pdesc).HasColumnName("PDESC");
            entity.Property(e => e.Pname)
                .HasMaxLength(100)
                .HasColumnName("PNAME");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");

            entity.HasOne(d => d.PcategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Pcategory)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PRODUCTS__PCATEG__3B75D760");
        });

        modelBuilder.Entity<ProductPreview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT___3214EC27C40F6256");

            entity.ToTable("PRODUCT_PREVIEW");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Preview)
                .HasMaxLength(100)
                .HasColumnName("PREVIEW");
            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPreviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PRODUCT_P__PRODU__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
