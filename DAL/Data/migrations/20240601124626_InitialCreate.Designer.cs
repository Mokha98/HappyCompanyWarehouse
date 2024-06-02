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
    [Migration("20240601124626_InitialCreate")]
    partial class InitialCreate
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
                            PasswordHash = new byte[] { 140, 120, 182, 129, 77, 184, 86, 171, 244, 76, 237, 237, 255, 178, 247, 5, 5, 140, 150, 20, 4, 206, 34, 63, 107, 159, 223, 56, 97, 149, 93, 204, 86, 135, 169, 75, 228, 211, 110, 192, 195, 86, 64, 86, 111, 160, 246, 165, 33, 231, 122, 246, 77, 253, 196, 127, 71, 207, 203, 8, 151, 38, 220, 74 },
                            PasswordSalt = new byte[] { 166, 114, 176, 149, 93, 11, 157, 67, 205, 131, 137, 22, 205, 86, 0, 57, 202, 208, 234, 210, 57, 47, 95, 167, 149, 111, 152, 146, 35, 224, 162, 6, 192, 73, 139, 9, 40, 137, 242, 90, 39, 59, 247, 29, 175, 253, 206, 48, 244, 95, 96, 241, 52, 30, 120, 31, 36, 162, 241, 69, 251, 178, 24, 61, 223, 236, 87, 0, 188, 172, 35, 165, 73, 75, 2, 182, 42, 153, 230, 154, 161, 131, 147, 175, 201, 194, 1, 32, 113, 3, 56, 208, 21, 206, 125, 29, 180, 190, 192, 238, 93, 87, 212, 207, 87, 235, 97, 185, 201, 111, 89, 152, 42, 72, 186, 242, 143, 145, 164, 12, 150, 33, 185, 8, 197, 86, 165, 150 },
                            RoleId = 1
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

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

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
