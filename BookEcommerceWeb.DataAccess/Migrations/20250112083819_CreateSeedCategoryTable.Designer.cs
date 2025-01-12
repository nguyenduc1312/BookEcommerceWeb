﻿// <auto-generated />
using BookEcommerceWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookEcommerceWeb.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250112083819_CreateSeedCategoryTable")]
    partial class CreateSeedCategoryTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookEcommerceWeb.Models.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Hành động"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Khoa học viễn tưởng"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Lịch sử"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Ngôn tình"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Trinh thám"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
