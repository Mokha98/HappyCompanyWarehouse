﻿// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.data.migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240601163124_CountriesTable")]
    partial class CountriesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("DAL.Entity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@happywarehouse.com",
                            FullName = "Admin User",
                            IsActive = true,
                            PasswordHash = new byte[] { 250, 29, 133, 15, 227, 129, 178, 117, 175, 28, 88, 29, 145, 46, 18, 40, 36, 104, 20, 197, 199, 215, 173, 107, 124, 62, 254, 170, 72, 236, 120, 43, 1, 230, 6, 6, 248, 201, 10, 131, 248, 16, 40, 29, 65, 172, 221, 142, 30, 89, 10, 6, 150, 151, 119, 9, 29, 199, 177, 146, 97, 235, 42, 22 },
                            PasswordSalt = new byte[] { 89, 146, 92, 253, 80, 216, 62, 247, 125, 249, 176, 162, 190, 156, 218, 95, 110, 101, 79, 101, 139, 246, 37, 255, 58, 198, 17, 132, 133, 40, 37, 132, 50, 40, 106, 253, 211, 14, 30, 219, 176, 171, 8, 198, 8, 88, 3, 244, 72, 170, 172, 140, 246, 13, 144, 251, 105, 96, 62, 147, 99, 78, 184, 149, 74, 94, 209, 12, 64, 96, 36, 162, 249, 255, 76, 164, 78, 180, 209, 240, 71, 173, 199, 161, 125, 56, 199, 102, 104, 210, 211, 86, 238, 130, 84, 27, 136, 4, 249, 41, 91, 146, 196, 144, 249, 233, 176, 105, 103, 193, 59, 154, 4, 65, 134, 64, 36, 69, 116, 202, 255, 24, 233, 95, 45, 227, 190, 254 },
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("DAL.Entity.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jordan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Palestine"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = 4,
                            Name = "UAE"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Saudi Arabia"
                        });
                });

            modelBuilder.Entity("DAL.Entity.RoleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RoleType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Management"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Auditor"
                        });
                });

            modelBuilder.Entity("DAL.Entity.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("WarehouseName")
                        .IsUnique();

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DAL.Entity.WarehouseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("MSRPPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("Qty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SKUCode")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemName")
                        .IsUnique();

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseItems");
                });

            modelBuilder.Entity("DAL.Entity.AppUser", b =>
                {
                    b.HasOne("DAL.Entity.RoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleType");
                });

            modelBuilder.Entity("DAL.Entity.Warehouse", b =>
                {
                    b.HasOne("DAL.Entity.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DAL.Entity.WarehouseItem", b =>
                {
                    b.HasOne("DAL.Entity.Warehouse", "Warehouse")
                        .WithMany("WarehouseItems")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DAL.Entity.Warehouse", b =>
                {
                    b.Navigation("WarehouseItems");
                });
#pragma warning restore 612, 618
        }
    }
}
