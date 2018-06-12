using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace MVCECommerceRemake.Models
{
    public partial class ADMINContext : DbContext
    {
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersCustomersLink> OrdersCustomersLink { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsOrdersLink> ProductsOrdersLink { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);
            }
        }

        public ADMINContext(DbContextOptions<ADMINContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProductId });

                entity.ToTable("BASKET");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CUSTOMER_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId)
                    .HasName("PRODUCT_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CUSTOMER_ID")
                    .HasColumnType("decimal(20,0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("PRODUCT_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("CUSTOMERS");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CUSTOMER_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnName("ADDRESS_LINE1")
                    .HasMaxLength(100);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("ADDRESS_LINE2")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.HouseNameNo)
                    .HasColumnName("HOUSE_NAME_NO")
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("PHONE")
                    .HasMaxLength(100);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("POSTCODE")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("ORDERS");

                entity.HasIndex(e => e.OrderId)
                    .HasName("ORDER_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.OrderId)
                    .HasColumnName("ORDER_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.OrderDate)
                    .IsRequired()
                    .HasColumnName("ORDER_DATE")
                    .HasMaxLength(20);

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasColumnName("ORDER_STATUS")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<OrdersCustomersLink>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.OrderId });

                entity.ToTable("ORDERS_CUSTOMERS_LINK");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CUSTOMER_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.OrderId)
                    .HasName("ORDER_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CUSTOMER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("ORDER_ID")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("PRODUCTS");

                entity.HasIndex(e => e.ProductId)
                    .HasName("PRODUCT_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.ProductCategory)
                    .HasColumnName("PRODUCT_CATEGORY")
                    .HasMaxLength(16);

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("PRODUCT_DESCRIPTION")
                    .HasMaxLength(150);

                entity.Property(e => e.ProductName)
                    .HasColumnName("PRODUCT_NAME")
                    .HasMaxLength(60);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("PRODUCT_PRICE")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ProductQuantity)
                    .IsRequired()
                    .HasColumnName("PRODUCT_QUANTITY")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ProductsOrdersLink>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("PRODUCTS_ORDERS_LINK");

                entity.HasIndex(e => e.OrderId)
                    .HasName("ORDER_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId)
                    .HasName("PRODUCT_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.OrderId)
                    .HasColumnName("ORDER_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.ProductId)
                    .HasColumnName("PRODUCT_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.QuantityOrdered)
                    .IsRequired()
                    .HasColumnName("QUANTITY_ORDERED")
                    .HasMaxLength(20);
            });
        }
    }
}
