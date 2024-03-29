﻿using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Entities.Address;
using GoogleAPI.Domain.Entities.All_Settings;
using GoogleAPI.Domain.Entities.Cargo;
using GoogleAPI.Domain.Entities.Common;
using GoogleAPI.Domain.Entities.PaymentEntities;
using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Domain.Models.Brand.ViewModel;
using GoogleAPI.Domain.Models.Product.Dto;
using GoogleAPI.Domain.Models.Product.ViewModel;
using Microsoft.EntityFrameworkCore;
using Order = GoogleAPI.Domain.Entities.Order;


namespace GoogleAPI.Persistance.Contexts
{
    public class GooleAPIDbContext : DbContext
    {

        public GooleAPIDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    if (entityType.ClrType.IsSubclassOf(typeof(BaseEntity)))
            //    {
            //        modelBuilder.Entity(entityType.ClrType)
            //            .Property("UpdatedDate")
            //            .HasDefaultValue(DateTime.Now);
            //    }
            //}
            #region products

            modelBuilder.Entity<ProductCategory>()
            .HasKey(pp => new { pp.ProductId, pp.CategoryId });


            modelBuilder.Entity<ProductPhoto>()
                 .HasKey(pp => new { pp.ProductId, pp.PhotoId });

            modelBuilder.Entity<Product>().HasOne(p => p.Brand).WithMany(c => c.Products).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Product>().HasOne(p => p.Dimension).WithMany(c => c.Products).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Product>().HasOne(p => p.Color).WithMany(c => c.Products).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Product>().HasOne(p => p.Supplier).WithMany(c => c.Products).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ProductCard_VM>().HasNoKey();
            modelBuilder.Entity<ProductDetail_DTO>().HasNoKey();

            #endregion
            #region orders and basket 
            modelBuilder.Entity<Order>().HasOne(u => u.Basket).WithOne(b => b.Order).IsRequired(false).OnDelete(DeleteBehavior.SetNull); // Silme 
            modelBuilder.Entity<Order>().HasOne(u => u.ShippingAddress).WithMany(b => b.Orders).IsRequired(false).OnDelete(DeleteBehavior.SetNull); // Silme 
            //modelBuilder.Entity<Order>().HasOne(u => u.BillingAddress).WithMany(b => b.Orders).IsRequired(false).OnDelete(DeleteBehavior.SetNull); // Silme 
            modelBuilder.Entity<Basket>().HasOne(u => u.User).WithMany(b => b.Baskets).IsRequired(false).OnDelete(DeleteBehavior.SetNull); // Silme 

            modelBuilder.Entity<Order>().HasOne(u => u.MarketPlace).WithMany(b => b.Orders).IsRequired(false).OnDelete(DeleteBehavior.SetNull); // Silme 
            modelBuilder.Entity<BasketItem>().HasOne(u => u.Basket).WithMany(b => b.BasketItems).IsRequired(false).OnDelete(DeleteBehavior.SetNull); // Silme 
            modelBuilder.Entity<BasketItem>().HasOne(u => u.Product).WithMany(b => b.BasketItems).IsRequired(false).OnDelete(DeleteBehavior.SetNull); // Silme 

            modelBuilder.Entity<ShippingAddress>().HasOne(a => a.User).WithMany(u => u.ShippingAddresses).IsRequired(false).OnDelete(DeleteBehavior.SetNull);

            #endregion
            #region user
            modelBuilder.Entity<RoleUser>()
           .HasKey(pp => new { pp.UserId, pp.RoleId });
            //modelBuilder.Entity<User>().HasOne(p => p.Role).WithMany(c => c.Users).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<BillingAddress>().HasOne(u => u.User).WithMany(b => b.BillingAddresses).IsRequired(false).OnDelete(DeleteBehavior.Restrict); // Silme davranışını özelleştirir
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsOrderBanned)
                      .HasDefaultValue(false);
                entity.Property(e => e.IsRemitPaymentBanned)
                    .HasDefaultValue(false)
                            .HasDefaultValue(false);
                entity.Property(e => e.IsRemitPaymentBanned)
                    .HasDefaultValue(false);
              
            });

            #endregion

            //modelBuilder.Entity<BillingAddress>().HasOne(p => p.Country).WithMany(c => c.BillingAddresses).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<BillingAddress>().HasOne(p => p.Province).WithMany(c => c.BillingAddresses).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<BillingAddress>().HasOne(p => p.District).WithMany(c => c.BillingAddresses).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<BillingAddress>().HasOne(p => p.Neighborhood).WithMany(c => c.BillingAddresses).IsRequired(false).OnDelete(DeleteBehavior.NoAction);



            // Diğer konfigürasyonlar ve ilişkiler...


            //modelBuilder.Entity<Order>().HasOne<Payment>().WithMany(c => c.Orders).OnDelete(DeleteBehavior.SetNull);


            //modelBuilder.Entity<Payment>().HasOne<PaymentMethod>().WithMany(c => c.Payments).OnDelete(DeleteBehavior.SetNull); PaymentFirmInfo CompanyInfo

        }
        public DbSet<MailInfo>? MailInfos{ get; set; }
        //public DbSet<PaymentFirmInfo>? PaymentFirmInfos { get; set; }
        public DbSet<CompanyInfo>? CompanyInfos { get; set; }
        public DbSet<PopUp>? PopUps { get; set; }
        public DbSet<PopUpType>? PopUpTypes { get; set; }


        public DbSet<Country>? Countries { get; set; }
        public DbSet<CargoFirm>? CargoFirms { get; set; }

        public DbSet<Province>? Provinces { get; set; }

        public DbSet<District>? Districts { get; set; }

        public DbSet<Neighborhood>? Neighborhoods { get; set; }

        public DbSet<Menu>? Menus { get; set; }
        public DbSet<Endpoint>? Endpoints { get; set; }
        public DbSet<RoleUser>? RoleUsers { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<ShippingAddress>? ShippingAddresses { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderStatus>? OrderStatuses { get; set; }

        public DbSet<OrderShipmentStatus>? OrderShipmentStatuses { get; set; }

        public DbSet<OrderPaymentStatus>? OrderPaymentStatuses { get; set; }

        public DbSet<OrderProvider>? OrderProviders { get; set; }

        public DbSet<Basket>? Baskets { get; set; }
        public DbSet<BasketItem>? BasketItems { get; set; }
        public DbSet<ProductPhoto>? ProductPhotos { get; set; }
        public DbSet<MarketPlace>? MarketPlaces { get; set; }

        public DbSet<ProductCategory>? ProductCategories { get; set; }
        public DbSet<Role>? Roles { get; set; }
        //public DbSet<BillingAddress>? BillingAddresses { get; set; }

        public DbSet<Personal>? Personals { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Color>? Colors { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Photo>? Photos { get; set; }
        public DbSet<Dimension>? Dimensions { get; set; }
        public DbSet<Category>? Categories { get; set; }
        //public DbSet<Log>? Logs { get; set; }

        public DbSet<ProductVariation_VM>? ProductVariation_VM { get; set; }
        public DbSet<Brand_VM>? Brand_VM { get; set; }
        public DbSet<ProductCard_VM>? ProductCard_VM { get; set; }
        public DbSet<ProductDetail_DTO>? ProductDetail_DTO { get; set; }

        public DbSet<Payment>? Payments { get; set; }

        public DbSet<PaymentMethod>? PaymentMethods { get; set; }


        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
        )
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
