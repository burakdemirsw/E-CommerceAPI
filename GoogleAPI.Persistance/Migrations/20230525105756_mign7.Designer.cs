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
    [Migration("20230525105756_mign7")]
    partial class mign7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BarcodeBarcodeType", b =>
                {
                    b.Property<int>("BarcodeTypesId")
                        .HasColumnType("int");

                    b.Property<int>("BarcodesId")
                        .HasColumnType("int");

                    b.HasKey("BarcodeTypesId", "BarcodesId");

                    b.HasIndex("BarcodesId");

                    b.ToTable("BarcodeBarcodeType");
                });

            modelBuilder.Entity("ColorVariation", b =>
                {
                    b.Property<int>("ColorsId")
                        .HasColumnType("int");

                    b.Property<int>("VariationsId")
                        .HasColumnType("int");

                    b.HasKey("ColorsId", "VariationsId");

                    b.HasIndex("VariationsId");

                    b.ToTable("ColorVariation");
                });

            modelBuilder.Entity("DimentionVariation", b =>
                {
                    b.Property<int>("DimentionsId")
                        .HasColumnType("int");

                    b.Property<int>("VariationsId")
                        .HasColumnType("int");

                    b.HasKey("DimentionsId", "VariationsId");

                    b.HasIndex("VariationsId");

                    b.ToTable("DimentionVariation");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Barcode", b =>
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
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Barcodes");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.BarcodeType", b =>
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

                    b.Property<int>("FixedNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BarcodeTypes");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCardId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.HasIndex("ProductCardId");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Dimention", b =>
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
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Dimentions");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhotoTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoTypeId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.PhotoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CategoryPhoto")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ProductPhoto")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PhotoTypes");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BarcodeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCardId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductStockId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VariationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BarcodeId")
                        .IsUnique();

                    b.HasIndex("ProductCardId");

                    b.HasIndex("ProductStockId")
                        .IsUnique();

                    b.HasIndex("VariationId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Blocked")
                        .HasColumnType("bit");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<bool?>("CardBlocked")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("FreeShipping")
                        .HasColumnType("bit");

                    b.Property<bool?>("New")
                        .HasColumnType("bit");

                    b.Property<int>("ProductPriceId")
                        .HasColumnType("int");

                    b.Property<int>("ProductPropertyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductSeoDetailId")
                        .HasColumnType("int");

                    b.Property<bool?>("ShowCase")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductPriceId")
                        .IsUnique();

                    b.HasIndex("ProductPropertyId");

                    b.HasIndex("ProductSeoDetailId");

                    b.ToTable("ProductCards");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberTypePrice1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberTypePrice9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProductPriceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductDetailId");

                    b.HasIndex("ProductPriceTypeId");

                    b.ToTable("ProductPrices");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductPriceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPriceTypes");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("KeyWords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCardId")
                        .HasColumnType("int");

                    b.Property<string>("SalesUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField10")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField7")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField8")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialField9")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductCardId");

                    b.ToTable("ProductProperty");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductSeoDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductCardId")
                        .HasColumnType("int");

                    b.Property<string>("RateValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoHeaderLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoPageDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductCardId");

                    b.ToTable("ProductSeoDetails");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dimention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("In_Qty1")
                        .HasColumnType("int");

                    b.Property<int>("In_Qty2")
                        .HasColumnType("int");

                    b.Property<int>("Out_Qty1")
                        .HasColumnType("int");

                    b.Property<int>("Out_Qty2")
                        .HasColumnType("int");

                    b.Property<string>("StockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductStocks");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductCardId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductCardId");

                    b.ToTable("SubCategorys");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Variation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Variations");
                });

            modelBuilder.Entity("GooleAPI.Application.Models.VM_Get_ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Blocked")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("New")
                        .HasColumnType("bit");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PurchasePrice")
                        .HasColumnType("int");

                    b.Property<int?>("SellingPrice")
                        .HasColumnType("int");

                    b.Property<int?>("StockAmount")
                        .HasColumnType("int");

                    b.Property<string>("StockCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VM_Get_ProductModels");
                });

            modelBuilder.Entity("PhotoProductCard", b =>
                {
                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCardsId")
                        .HasColumnType("int");

                    b.HasKey("PhotoId", "ProductCardsId");

                    b.HasIndex("ProductCardsId");

                    b.ToTable("PhotoProductCard");
                });

            modelBuilder.Entity("BarcodeBarcodeType", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.BarcodeType", null)
                        .WithMany()
                        .HasForeignKey("BarcodeTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.Barcode", null)
                        .WithMany()
                        .HasForeignKey("BarcodesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ColorVariation", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Color", null)
                        .WithMany()
                        .HasForeignKey("ColorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.Variation", null)
                        .WithMany()
                        .HasForeignKey("VariationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DimentionVariation", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Dimention", null)
                        .WithMany()
                        .HasForeignKey("DimentionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.Variation", null)
                        .WithMany()
                        .HasForeignKey("VariationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Category", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Photo", "Photo")
                        .WithOne("Category")
                        .HasForeignKey("GoogleAPI.Domain.Entities.Category", "PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductCard", "ProductCard")
                        .WithMany()
                        .HasForeignKey("ProductCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("ProductCard");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Photo", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.PhotoType", "PhotoType")
                        .WithMany("Photos")
                        .HasForeignKey("PhotoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhotoType");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Product", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Barcode", "Barcode")
                        .WithOne("Product")
                        .HasForeignKey("GoogleAPI.Domain.Entities.Product", "BarcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductCard", "ProductCard")
                        .WithMany("Products")
                        .HasForeignKey("ProductCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductStock", "ProductStock")
                        .WithOne("Product")
                        .HasForeignKey("GoogleAPI.Domain.Entities.Product", "ProductStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.Variation", "Variation")
                        .WithMany()
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barcode");

                    b.Navigation("ProductCard");

                    b.Navigation("ProductStock");

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductCard", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Brand", "Brand")
                        .WithMany("ProductCards")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductPrice", "ProductPrice")
                        .WithOne("ProductCard")
                        .HasForeignKey("GoogleAPI.Domain.Entities.ProductCard", "ProductPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductProperty", "ProductProperty")
                        .WithMany()
                        .HasForeignKey("ProductPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductSeoDetail", "ProductSeoDetail")
                        .WithMany()
                        .HasForeignKey("ProductSeoDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("ProductPrice");

                    b.Navigation("ProductProperty");

                    b.Navigation("ProductSeoDetail");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductPrice", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Product", "ProductDetail")
                        .WithMany()
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductPriceType", "ProductPriceType")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductPriceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDetail");

                    b.Navigation("ProductPriceType");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductPriceType", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductProperty", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.ProductCard", "ProductCard")
                        .WithMany()
                        .HasForeignKey("ProductCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCard");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductSeoDetail", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.ProductCard", "ProductCard")
                        .WithMany()
                        .HasForeignKey("ProductCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCard");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.SubCategory", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductCard", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("ProductCardId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PhotoProductCard", b =>
                {
                    b.HasOne("GoogleAPI.Domain.Entities.Photo", null)
                        .WithMany()
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoogleAPI.Domain.Entities.ProductCard", null)
                        .WithMany()
                        .HasForeignKey("ProductCardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Barcode", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Brand", b =>
                {
                    b.Navigation("ProductCards");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.Photo", b =>
                {
                    b.Navigation("Category")
                        .IsRequired();
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.PhotoType", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductCard", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductPrice", b =>
                {
                    b.Navigation("ProductCard")
                        .IsRequired();
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductPriceType", b =>
                {
                    b.Navigation("ProductPrices");
                });

            modelBuilder.Entity("GoogleAPI.Domain.Entities.ProductStock", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
