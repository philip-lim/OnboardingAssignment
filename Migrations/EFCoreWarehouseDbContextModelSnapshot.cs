﻿// <auto-generated />
using System;
using CRUDCoreReact.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDCoreReact.Migrations
{
    [DbContext(typeof(EFCoreWarehouseDbContext))]
    partial class EFCoreWarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDCoreReact.Models.CustomerModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CRUDCoreReact.Models.ProductModel", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<string>("ProductPrice")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CRUDCoreReact.Models.SalesModel", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateSold")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("ProductId");

                    b.Property<int>("StoreId");

                    b.HasKey("SalesId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("CRUDCoreReact.Models.StoreModel", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StoreAddress")
                        .IsRequired();

                    b.Property<string>("StoreName")
                        .IsRequired();

                    b.HasKey("StoreId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("CRUDCoreReact.Models.SalesModel", b =>
                {
                    b.HasOne("CRUDCoreReact.Models.CustomerModel", "CustomerModel")
                        .WithMany("SalesModels")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRUDCoreReact.Models.ProductModel", "ProductModel")
                        .WithMany("SalesModels")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRUDCoreReact.Models.StoreModel", "StoreModel")
                        .WithMany("SalesModels")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}