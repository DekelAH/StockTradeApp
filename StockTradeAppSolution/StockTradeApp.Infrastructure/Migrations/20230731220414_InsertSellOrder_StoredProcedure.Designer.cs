﻿// <auto-generated />
using System;
using Entities.DbContextModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace StockTradeApp.Infrastructure.Migrations
{
    [DbContext(typeof(StockMarketDbContext))]
    [Migration("20230731220414_InsertSellOrder_StoredProcedure")]
    partial class InsertSellOrder_StoredProcedure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.BuyOrder", b =>
                {
                    b.Property<Guid>("BuyOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateAndTimeOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("StockName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StockSymbol")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BuyOrderID");

                    b.ToTable("BuyOrders", (string)null);
                });

            modelBuilder.Entity("Entities.Models.SellOrder", b =>
                {
                    b.Property<Guid>("SellOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateAndTimeOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("StockName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StockSymbol")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SellOrderID");

                    b.ToTable("SellOrders", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
