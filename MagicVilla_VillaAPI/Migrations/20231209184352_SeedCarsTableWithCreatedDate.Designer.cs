﻿// <auto-generated />
using System;
using MagicVilla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231209184352_SeedCarsTableWithCreatedDate")]
    partial class SeedCarsTableWithCreatedDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_VillaAPI.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Rolls Royce",
                            CountryOfOrigin = "England",
                            CreatedDate = new DateTime(2023, 12, 9, 19, 43, 52, 102, DateTimeKind.Local).AddTicks(2951),
                            Description = "You already know what it is",
                            MaxSpeed = 300,
                            Model = "Phantom",
                            Price = 1000000f
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Tesla",
                            CountryOfOrigin = "US",
                            CreatedDate = new DateTime(2023, 12, 9, 19, 43, 52, 102, DateTimeKind.Local).AddTicks(3013),
                            Description = "You already know what it is",
                            MaxSpeed = 200,
                            Model = "S",
                            Price = 200000f
                        },
                        new
                        {
                            Id = 3,
                            Brand = "S",
                            CountryOfOrigin = "England",
                            CreatedDate = new DateTime(2023, 12, 9, 19, 43, 52, 102, DateTimeKind.Local).AddTicks(3016),
                            Description = "You already know what it is",
                            MaxSpeed = 500,
                            Model = "Trash",
                            Price = 55f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
