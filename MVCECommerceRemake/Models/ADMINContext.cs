using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCECommerceRemake.Models
{
    public partial class ADMINContext : DbContext
    {
        public ADMINContext()
        {
        }

        public ADMINContext(DbContextOptions<ADMINContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Name).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderKey).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderDisplayName).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId).HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Address1).HasColumnType("longtext");

                entity.Property(e => e.Address2).HasColumnType("longtext");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Email).HasColumnType("varchar(256)");

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.FirstName).HasColumnType("longtext");

                entity.Property(e => e.HouseName).HasColumnType("longtext");

                entity.Property(e => e.LastName).HasColumnType("longtext");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedUserName).HasColumnType("varchar(256)");

                entity.Property(e => e.PasswordHash).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumber).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.Postcode).HasColumnType("longtext");

                entity.Property(e => e.SecurityStamp).HasColumnType("longtext");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

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
                    .HasColumnType("int(4)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("PRODUCT_ID")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("CUSTOMERS");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CUSTOMER_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CUSTOMER_ID")
                    .HasColumnType("int(4)");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnName("ADDRESS_LINE1")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("ADDRESS_LINE2")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.HouseNameNo)
                    .HasColumnName("HOUSE_NAME_NO")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("PHONE")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("POSTCODE")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
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
                    .HasColumnType("int(4)");

                entity.Property(e => e.OrderDate)
                    .IsRequired()
                    .HasColumnName("ORDER_DATE")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasColumnName("ORDER_STATUS")
                    .HasColumnType("varchar(30)");
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
                    .HasColumnType("int(4)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("ORDER_ID")
                    .HasColumnType("int(4)");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("PRODUCTS");

                entity.HasIndex(e => e.ProductId)
                    .HasName("PRODUCT_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasColumnName("PRODUCT_ID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.ProductCategory)
                    .HasColumnName("PRODUCT_CATEGORY")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("PRODUCT_DESCRIPTION")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("PRODUCT_NAME")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("PRODUCT_PRICE")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ProductQuantity)
                    .HasColumnName("PRODUCT_QUANTITY")
                    .HasColumnType("int(3)");
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
                    .HasColumnType("int(4)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("PRODUCT_ID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.QuantityOrdered)
                    .HasColumnName("QUANTITY_ORDERED")
                    .HasColumnType("int(4)");
            });
        }
    }
}
