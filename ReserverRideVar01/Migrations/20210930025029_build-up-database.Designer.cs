﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserverRideVar01.DbContext;

namespace ReserverRideVar01.Migrations
{
    [DbContext(typeof(MSITDbContext))]
    [Migration("20210930025029_build-up-database")]
    partial class buildupdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReserverRideVar01.Models.Island", b =>
                {
                    b.Property<int>("IslandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IslandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IslandId");

                    b.ToTable("Island");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IslandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCost")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProductPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int");

                    b.Property<int>("ProductQty")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("IslandId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ShoppingCost")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ShoppingPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("ShoppingPrice")
                        .HasColumnType("int");

                    b.Property<int?>("ShoppingQty")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IslandId")
                        .HasColumnType("int");

                    b.Property<string>("StoreAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StorePhone")
                        .HasColumnType("int");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.Product", b =>
                {
                    b.HasOne("ReserverRideVar01.Models.Island", "Island")
                        .WithMany("Products")
                        .HasForeignKey("IslandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Island");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.Island", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
