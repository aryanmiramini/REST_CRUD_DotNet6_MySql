﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REST_MySql.Services;

#nullable disable

namespace REST_MySql.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230124060728_ReCreate")]
    partial class ReCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("REST_MySql.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("BookMaterial")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BookS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Injaneb",
                            BookMaterial = 1,
                            Language = "Persian",
                            Title = "Test1"
                        },
                        new
                        {
                            Id = 2,
                            Author = "NotInjaneb",
                            BookMaterial = 0,
                            Language = "English",
                            Title = "Test3"
                        },
                        new
                        {
                            Id = 3,
                            Author = "NotInjaneb",
                            BookMaterial = 1,
                            Language = "English",
                            Title = "Test4"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Arabdude",
                            BookMaterial = 1,
                            Language = "Arabic",
                            Title = "Test5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
