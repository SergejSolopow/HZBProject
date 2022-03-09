﻿// <auto-generated />
using System;
using BeamlineX.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeamlineX.Repositories.Migrations
{
    [DbContext(typeof(BeamlineXDbContext))]
    [Migration("20220306114302_AddMeasureSetValues")]
    partial class AddMeasureSetValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BeamlineX.Domain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BeamlineX.Domain.Documents.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("BeamlineX.Domain.MeasureSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("AnglePosition")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Intensity")
                        .HasColumnType("double precision");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("MeasureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("MonochromatorPos")
                        .HasColumnType("double precision");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("MeasureSet");
                });

            modelBuilder.Entity("BeamlineX.Domain.Documents.Document", b =>
                {
                    b.HasOne("BeamlineX.Domain.Customer", "Customer")
                        .WithMany("Documents")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BeamlineX.Domain.Customer", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
