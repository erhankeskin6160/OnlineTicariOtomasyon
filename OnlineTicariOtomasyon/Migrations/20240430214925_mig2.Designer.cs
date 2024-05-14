﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineTicariOtomasyon.Models.Classes;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240430214925_mig2")]
    partial class mig2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("Authority")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("Char(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("Varchar(10)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("Varchar(10)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"), 1L, 1);

                    b.Property<string>("BillNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("Varchar(6)");

                    b.Property<string>("BillSequenceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillSeriNo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("Char(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryPerson")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.Property<DateTime>("Hour")
                        .HasColumnType("datetime2");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("TaxAdministration")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("Varchar(60)");

                    b.HasKey("BillId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Bill_Item", b =>
                {
                    b.Property<int>("BillItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillItemId"), 1L, 1);

                    b.Property<int>("BillsBillId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BillItemId");

                    b.HasIndex("BillsBillId");

                    b.ToTable("Bill_Items");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Cost", b =>
                {
                    b.Property<int>("CostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CostId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CostDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar(100)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("CostId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Current", b =>
                {
                    b.Property<int>("CurrentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CurrentId"), 1L, 1);

                    b.Property<string>("CurrentCity")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("CurrentLastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("CurrentMail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("CurrentName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.HasKey("CurrentId");

                    b.ToTable("Currents");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Personel", b =>
                {
                    b.Property<int>("PersonelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelId"), 1L, 1);

                    b.Property<int>("DepartmentsDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("PersoneImage")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("Varchar(300)");

                    b.Property<string>("PersonelName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("Personel_Last_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.HasKey("PersonelId");

                    b.HasIndex("DepartmentsDepartmentId");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("Product_Img")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("Varchar(300)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<short>("Stock")
                        .HasColumnType("smallint");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.SalesActivity", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesId"), 1L, 1);

                    b.Property<int>("CurrentsCurrentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonelsPersonelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesId");

                    b.HasIndex("CurrentsCurrentId");

                    b.HasIndex("PersonelsPersonelId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("SalesActivities");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Bill_Item", b =>
                {
                    b.HasOne("OnlineTicariOtomasyon.Models.Classes.Bill", "Bills")
                        .WithMany("Bill_İtems")
                        .HasForeignKey("BillsBillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bills");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Personel", b =>
                {
                    b.HasOne("OnlineTicariOtomasyon.Models.Classes.Department", "Departments")
                        .WithMany("Personels")
                        .HasForeignKey("DepartmentsDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Product", b =>
                {
                    b.HasOne("OnlineTicariOtomasyon.Models.Classes.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.SalesActivity", b =>
                {
                    b.HasOne("OnlineTicariOtomasyon.Models.Classes.Current", "Currents")
                        .WithMany("SalesActivitys")
                        .HasForeignKey("CurrentsCurrentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineTicariOtomasyon.Models.Classes.Personel", "Personels")
                        .WithMany("SalesActivitys")
                        .HasForeignKey("PersonelsPersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineTicariOtomasyon.Models.Classes.Product", "Products")
                        .WithMany("SalesActivitys")
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currents");

                    b.Navigation("Personels");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Bill", b =>
                {
                    b.Navigation("Bill_İtems");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Current", b =>
                {
                    b.Navigation("SalesActivitys");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Department", b =>
                {
                    b.Navigation("Personels");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Personel", b =>
                {
                    b.Navigation("SalesActivitys");
                });

            modelBuilder.Entity("OnlineTicariOtomasyon.Models.Classes.Product", b =>
                {
                    b.Navigation("SalesActivitys");
                });
#pragma warning restore 612, 618
        }
    }
}
