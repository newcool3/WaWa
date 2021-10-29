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
    [Migration("20211028025945_combine-db")]
    partial class combinedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReserverRideVar01.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ActivityDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActivityDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ActivityEndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ActivityLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActivityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActivityNumberLimit")
                        .HasColumnType("int");

                    b.Property<byte[]>("ActivityPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ActivityPrice")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ActivityStartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ActivityState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActivityTimezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IslandId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.HasIndex("IslandId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.ActivityOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId")
                        .HasColumnType("int");

                    b.Property<string>("OrderCheck")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderCustom")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderGuid")
                        .HasColumnType("int");

                    b.Property<string>("OrderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderTimezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderTotalPrice")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderUpdatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("ActivityId");

                    b.ToTable("ActivityOrders");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.Island", b =>
                {
                    b.Property<int>("IslandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IslandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("IslandPhoto")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IslandId");

                    b.ToTable("Island");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("MemberBirthday")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("MemberCreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MemberEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MemberEnable")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("MemberModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MemberNumberID")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MemberPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MemberPhone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("MemberPhoto")
                        .HasColumnType("varbinary");

                    b.Property<string>("MemberType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MemberID");

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

            modelBuilder.Entity("ReserverRideVar01.Models.Activity", b =>
                {
                    b.HasOne("ReserverRideVar01.Models.Island", "Island")
                        .WithMany()
                        .HasForeignKey("IslandId");

                    b.Navigation("Island");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.ActivityOrder", b =>
                {
                    b.HasOne("ReserverRideVar01.Models.Activity", "Activity")
                        .WithMany("ActivityOrders")
                        .HasForeignKey("ActivityId");

                    b.Navigation("Activity");
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

            modelBuilder.Entity("ReserverRideVar01.Models.Activity", b =>
                {
                    b.Navigation("ActivityOrders");
                });

            modelBuilder.Entity("ReserverRideVar01.Models.Island", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}