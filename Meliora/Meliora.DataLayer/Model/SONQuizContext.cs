using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Meliora.DataLayer.Model
{
    public partial class SONQuizContext : DbContext
    {
        public SONQuizContext()
        {
        }

        public SONQuizContext(DbContextOptions<SONQuizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<LineItem> LineItems { get; set; } = null!;
        public virtual DbSet<Mixins> Mixins { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<ProductMixinMap> ProductMixinMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appconnections.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("LineItem", "dbo")
                    .HasKey(e => e.Id);

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasPrincipalKey(e => e.Id);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasPrincipalKey(e => e.Id);
            });

            modelBuilder.Entity<Mixins>(entity =>
            {
                entity.ToTable("MIXINS", "dbo").HasKey(e => e.Id);
                entity.Property(e => e.Price).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "dbo")
                    .HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CustomerId");

                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "dbo")
                    .HasKey(e => e.Id);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery", "dbo")
                    .HasKey(e => e.Id);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "dbo")
                    .HasKey(e => e.Id);
            });

            modelBuilder.Entity<ProductMixinMap>(entity =>
            {
                entity.ToTable("ProductMixinMap", "dbo").HasKey(e => new { e.MapId, e.MixinId });

                entity.HasOne(e => e.Mixin).WithMany().HasForeignKey(x => x.MixinId).HasPrincipalKey(e => e.Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
