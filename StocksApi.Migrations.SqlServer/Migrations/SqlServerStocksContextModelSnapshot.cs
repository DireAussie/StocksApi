﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StocksApi.Migrations.SqlServer;

namespace StocksApi.Migrations.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerStocksContext))]
    partial class SqlServerStocksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("StocksApi.Model.Dividend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DividendAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FrankedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDividendReinvestmentPlan")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ReinvestmentNumberOfShares")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ReinvestmentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("StockId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("StockId");

                    b.ToTable("Dividend");
                });

            modelBuilder.Entity("StocksApi.Model.EndOfDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Close")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("High")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Low")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Open")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("StockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Volume")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("EndOfDay");
                });

            modelBuilder.Entity("StocksApi.Model.Holding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Brokerage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("NumberOfShares")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("StockId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("StockId");

                    b.ToTable("Holding");
                });

            modelBuilder.Entity("StocksApi.Model.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HolderIdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PortfolioManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioManagerId");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("StocksApi.Model.PortfolioManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PortfolioManager");
                });

            modelBuilder.Entity("StocksApi.Model.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndustryGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("StocksApi.Model.Dividend", b =>
                {
                    b.HasOne("StocksApi.Model.Portfolio", "Portfolio")
                        .WithMany("Dividends")
                        .HasForeignKey("PortfolioId");

                    b.HasOne("StocksApi.Model.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId");

                    b.Navigation("Portfolio");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StocksApi.Model.EndOfDay", b =>
                {
                    b.HasOne("StocksApi.Model.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StocksApi.Model.Holding", b =>
                {
                    b.HasOne("StocksApi.Model.Portfolio", "Portfolio")
                        .WithMany("Holdings")
                        .HasForeignKey("PortfolioId");

                    b.HasOne("StocksApi.Model.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId");

                    b.Navigation("Portfolio");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StocksApi.Model.Portfolio", b =>
                {
                    b.HasOne("StocksApi.Model.PortfolioManager", "PortfolioManager")
                        .WithMany("Portfolios")
                        .HasForeignKey("PortfolioManagerId");

                    b.Navigation("PortfolioManager");
                });

            modelBuilder.Entity("StocksApi.Model.Portfolio", b =>
                {
                    b.Navigation("Dividends");

                    b.Navigation("Holdings");
                });

            modelBuilder.Entity("StocksApi.Model.PortfolioManager", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
