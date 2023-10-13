﻿// <auto-generated />
using System;
using EndOfDateReportService.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EndOfDateReportService.Migrations
{
    [DbContext(typeof(ReportContext))]
    [Migration("20231013011037_NoteAdjustmentsMigration")]
    partial class NoteAdjustmentsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EndOfDateReportService.Domain.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Moore Wilsons Wellington"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Moore Wilsons Porirua"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Moore Wilsons Lower Hutt"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Moore Wilsons Masterton"
                        });
                });

            modelBuilder.Entity("EndOfDateReportService.Domain.Lane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<int>("LaneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Lanes");
                });

            modelBuilder.Entity("EndOfDateReportService.Domain.NoteAdjustments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<double?>("CallAdjustments")
                        .HasColumnType("double precision");

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LaneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("NotesAdjustments");
                });

            modelBuilder.Entity("EndOfDateReportService.Domain.PaymentMethod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("ActualAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<int>("LaneId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ReportedAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalVariance")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("LaneId");

                    b.HasIndex("Name", "LaneId", "BranchId", "ReportDate")
                        .IsUnique();

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("EndOfDateReportService.Domain.Lane", b =>
                {
                    b.HasOne("EndOfDateReportService.Domain.Branch", "Branch")
                        .WithMany("Lanes")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("EndOfDateReportService.Domain.PaymentMethod", b =>
                {
                    b.HasOne("EndOfDateReportService.Domain.Lane", "Lane")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("LaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lane");
                });

            modelBuilder.Entity("EndOfDateReportService.Domain.Branch", b =>
                {
                    b.Navigation("Lanes");
                });

            modelBuilder.Entity("EndOfDateReportService.Domain.Lane", b =>
                {
                    b.Navigation("PaymentMethods");
                });
#pragma warning restore 612, 618
        }
    }
}
