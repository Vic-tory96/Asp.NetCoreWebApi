﻿// <auto-generated />
using System;
using DataAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAPI.Migrations
{
    [DbContext(typeof(ContactContext))]
    [Migration("20230401123136_NewInitialMigration")]
    partial class NewInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModelAPI.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "456 Elm Street",
                            CreatedDate = new DateTime(2023, 4, 1, 13, 31, 35, 910, DateTimeKind.Local).AddTicks(55),
                            Email = "janesmith@example.com",
                            FullName = "Jane Smith",
                            ImageUrl = "https://example.com/janesmith.jpg",
                            MobilePhone = "09087654321",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Address = "123 Main Street",
                            CreatedDate = new DateTime(2023, 4, 1, 13, 31, 35, 910, DateTimeKind.Local).AddTicks(115),
                            Email = "johndoe@example.com",
                            FullName = "John Doe",
                            ImageUrl = "https://example.com/johndoe.jpg",
                            MobilePhone = "08012345678",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak Street",
                            CreatedDate = new DateTime(2023, 4, 1, 13, 31, 35, 910, DateTimeKind.Local).AddTicks(117),
                            Email = "bobjohnson@example.com",
                            FullName = "Bob Johnson",
                            ImageUrl = "https://example.com/bobjohnson.jpg",
                            MobilePhone = "07011223344",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
