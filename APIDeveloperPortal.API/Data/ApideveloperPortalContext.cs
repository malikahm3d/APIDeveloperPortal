using System;
using System.Collections.Generic;
using APIDeveloperPortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDeveloperPortal.API.Data;

public partial class ApideveloperPortalContext : DbContext
{
    public ApideveloperPortalContext()
    {
    }

    public ApideveloperPortalContext(DbContextOptions<ApideveloperPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductService> ProductServices { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersProductsBridge> UsersProductsBridges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DAEKA63\\SQLEXPRESS;Initial Catalog=APIDeveloperPortal;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductName).HasMaxLength(500);
        });

        modelBuilder.Entity<ProductService>(entity =>
        {
            entity.Property(e => e.FunctionName).HasMaxLength(500);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductServices)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductServices_Products");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(500);
        });

        modelBuilder.Entity<UsersProductsBridge>(entity =>
        {
            entity.ToTable("Users_Products_Bridge");

            entity.HasOne(d => d.Product).WithMany(p => p.UsersProductsBridges)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Users_Products_Bridge_Products");

            entity.HasOne(d => d.User).WithMany(p => p.UsersProductsBridges)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Users_Products_Bridge_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
