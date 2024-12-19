﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalesApi.ORM.Contexts;

#nullable disable

namespace SalesApi.ORM.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    partial class SalesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sales")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SalesApi.Domain.Entities.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Percent")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SaleProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.HasIndex("SaleProductId");

                    b.ToTable("Discounts", "sales");
                });

            modelBuilder.Entity("SalesApi.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.ToTable("Products", "sales");
                });

            modelBuilder.Entity("SalesApi.Domain.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("boolean");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Sales", "sales");
                });

            modelBuilder.Entity("SalesApi.Domain.Entities.Discount", b =>
                {
                    b.HasOne("SalesApi.Domain.Entities.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesApi.Domain.Entities.Product", "SaleProduct")
                        .WithMany()
                        .HasForeignKey("SaleProductId");

                    b.Navigation("Sale");

                    b.Navigation("SaleProduct");
                });

            modelBuilder.Entity("SalesApi.Domain.Entities.Product", b =>
                {
                    b.HasOne("SalesApi.Domain.Entities.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });
#pragma warning restore 612, 618
        }
    }
}