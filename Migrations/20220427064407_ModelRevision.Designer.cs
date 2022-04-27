﻿// <auto-generated />
using BestiaryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BestiaryApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220427064407_ModelRevision")]
    partial class ModelRevision
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("BestiaryApi.Models.Beast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Immunity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Loot")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Occurrences")
                        .HasColumnType("TEXT");

                    b.Property<string>("Variations")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vulnerable")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Beasts");
                });
#pragma warning restore 612, 618
        }
    }
}