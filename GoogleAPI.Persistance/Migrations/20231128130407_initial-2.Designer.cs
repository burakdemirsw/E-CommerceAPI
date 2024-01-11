﻿// <auto-generated />
using System;
using GoogleAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    [DbContext(typeof(GooleAPIDbContext))]
    [Migration("20231128130407_initial-2")]
    partial class initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoogleAPI.Domain.DTO.ProductDetail_DTO", b =>
                {
                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NormalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StockCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Variations")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ProductDetail_DTO");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("BaskedNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8166));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BasketId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8397));

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8577));

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8692));

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8827));

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Dimension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8941));

                    b.HasKey("Id");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExceptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LoggedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9054));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BasketId")
                        .HasColumnType("int");

                    b.Property<int?>("BillingAddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("OrderNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ShippingAddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9194));

                    b.HasKey("Id");

                    b.HasIndex("BasketId")
                        .IsUnique()
                        .HasFilter("[BasketId] IS NOT NULL");

                    b.HasIndex("BillingAddressId");

                    b.HasIndex("ShippingAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9346));

                    b.HasKey("Id");

                    b.ToTable("Personals");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9489));

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("CoverLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DimensionId")
                        .HasColumnType("int");

                    b.Property<decimal?>("DiscountedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsFreeCargo")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsNew")
                        .HasColumnType("bit");

                    b.Property<decimal?>("NormalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StockAmount")
                        .HasColumnType("int");

                    b.Property<string>("StockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Ticket_1")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9597));

                    b.Property<int?>("VATRate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ColorId");

                    b.HasIndex("DimensionId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductPhoto", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "PhotoId");

                    b.HasIndex("PhotoId");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9772));

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.BillingAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorparateDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsCorporate")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsIndividual")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RowGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TCKN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxAuthorityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9890));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BillingAddresses");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(13));

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.ShippingAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RowGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(155));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShippingAddresses");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool?>("SubscribeToPromotions")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(281));

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Models.Brand_VM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand_VM");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Models.ProductCard_VM", b =>
                {
                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsFreeCargo")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsNew")
                        .HasColumnType("bit");

                    b.Property<decimal?>("NormalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalStockAmount")
                        .HasColumnType("int");

                    b.Property<int?>("VATRate")
                        .HasColumnType("int");

                    b.ToTable("ProductCard_VM");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Models.ProductVariation_VM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFreeCargo")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<decimal>("NormalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VATRate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductVariation_VM");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Basket", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.User.User", "User")
                        .WithMany("Baskets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.BasketItem", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GoogleAPI.Domain.Entities.Product", "Product")
                        .WithMany("BasketItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Order", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Basket", "Basket")
                        .WithOne("Order")
                        .HasForeignKey("GoogleAPI.Domain.Entities.Order", "BasketId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GoogleAPI.Domain.Entities.User.BillingAddress", "BillingAddress")
                        .WithMany("Orders")
                        .HasForeignKey("BillingAddressId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GoogleAPI.Domain.Entities.User.ShippingAddress", "ShippingAddress")
                        .WithMany("Orders")
                        .HasForeignKey("ShippingAddressId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Basket");

                    b.Navigation("BillingAddress");

                    b.Navigation("ShippingAddress");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Product", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GoogleAPI.Domain.Entities.Color", "Color")
                        .WithMany("Products")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GoogleAPI.Domain.Entities.Dimension", "Dimension")
                        .WithMany("Products")
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Brand");

                    b.Navigation("Color");

                    b.Navigation("Dimension");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductPhoto", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Photo", "Photo")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.BillingAddress", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.User.User", "User")
                        .WithMany("BillingAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.ShippingAddress", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.User.User", "User")
                        .WithMany("ShippingAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.User", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.User.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Basket", b =>
                {
                    b.Navigation("BasketItems");

                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Color", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Dimension", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Photo", b =>
                {
                    b.Navigation("ProductPhotos");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Product", b =>
                {
                    b.Navigation("BasketItems");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductPhotos");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.BillingAddress", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.ShippingAddress", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.User.User", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("BillingAddresses");

                    b.Navigation("ShippingAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}