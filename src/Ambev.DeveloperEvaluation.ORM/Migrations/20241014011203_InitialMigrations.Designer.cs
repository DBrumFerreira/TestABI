﻿// <auto-generated />
using System;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20241014011203_InitialMigrations")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
            });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Sale", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()");

                b.Property<int>("SaleNumber")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("serial");

                b.Property<DateTime>("SaleDate")
                    .HasColumnType("timestamp");

                b.Property<string>("CustomerName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)");

                b.Property<string>("Branch")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)");

                b.Property<decimal>("TotalAmount")
                    .HasColumnType("numeric(10,2)");

                b.Property<bool>("IsCancelled")
                    .HasColumnType("boolean")
                    .HasDefaultValue(false);

                b.HasKey("Id");

                b.ToTable("Sales", (string)null);
            });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Product", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)");

                b.Property<string>("Description")
                    .HasColumnType("text");

                b.Property<decimal>("Price")
                    .HasColumnType("numeric(10,2)");

                b.Property<DateTime>("CreatedAt")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.Property<DateTime?>("UpdatedAt")
                    .HasColumnType("timestamp");

                b.HasKey("Id");

                b.ToTable("Products", (string)null);
            });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SaleProduct", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()");

                b.Property<Guid>("SaleId")
                    .HasColumnType("uuid");

                b.Property<Guid>("ProductId")
                    .HasColumnType("uuid");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.Property<decimal>("UnitPrice")
                    .HasColumnType("numeric(10,2)");

                b.Property<decimal>("Discount")
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValue(0m);

                b.Property<decimal>("TotalItemAmount")
                    .HasColumnType("numeric(10,2)");

                b.HasKey("Id");

                b.HasIndex("SaleId");

                b.HasIndex("ProductId");

                b.ToTable("SaleProducts", (string)null);

                b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Sale", null)
                    .WithMany()
                    .HasForeignKey("SaleId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Product", null)
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}
