﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TAW_HLL_Campaign.Data;

#nullable disable

namespace TAW_HLL_Campaign.Migrations
{
    [DbContext(typeof(CampaignContext))]
    [Migration("20231108134954_nationEnum")]
    partial class nationEnum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Building", b =>
                {
                    b.Property<int>("BuildingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingID"), 1L, 1);

                    b.Property<int>("BuildingTypeID")
                        .HasColumnType("int");

                    b.HasKey("BuildingID");

                    b.ToTable("Building", (string)null);
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.BuildingType", b =>
                {
                    b.Property<int>("BuildingTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingTypeID"), 1L, 1);

                    b.Property<int?>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Income")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.HasKey("BuildingTypeID");

                    b.ToTable("BuildingType", (string)null);
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Defence", b =>
                {
                    b.Property<int>("DefenceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DefenceID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DefenceID");

                    b.ToTable("Defence", (string)null);
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Maneuver", b =>
                {
                    b.Property<int>("maneuverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maneuverId"), 1L, 1);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maneuverId");

                    b.ToTable("Maneuver", (string)null);
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Road", b =>
                {
                    b.Property<int>("RoadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoadID"), 1L, 1);

                    b.Property<int>("EndSectorID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartSectorID")
                        .HasColumnType("int");

                    b.HasKey("RoadID");

                    b.ToTable("Road", (string)null);
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectorId"), 1L, 1);

                    b.Property<int>("BuildSlots")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuppliesIncome")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<int>("VictoryPoints")
                        .HasColumnType("int");

                    b.HasKey("SectorId");

                    b.HasIndex("TeamID");

                    b.ToTable("Sector", (string)null);
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Stockpile", b =>
                {
                    b.Property<int>("StockpileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockpileID"), 1L, 1);

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<int>("TotalSupplies")
                        .HasColumnType("int");

                    b.Property<int>("TotalVictoryPoints")
                        .HasColumnType("int");

                    b.HasKey("StockpileID");

                    b.HasIndex("TeamID")
                        .IsUnique();

                    b.ToTable("Stockpile", (string)null);
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nation")
                        .HasColumnType("int");

                    b.HasKey("TeamID");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Sector", b =>
                {
                    b.HasOne("TAW_HLL_Campaign.Models.Team", "Team")
                        .WithMany("Sectors")
                        .HasForeignKey("TeamID");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Stockpile", b =>
                {
                    b.HasOne("TAW_HLL_Campaign.Models.Team", null)
                        .WithOne("Stockpile")
                        .HasForeignKey("TAW_HLL_Campaign.Models.Stockpile", "TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TAW_HLL_Campaign.Models.Team", b =>
                {
                    b.Navigation("Sectors");

                    b.Navigation("Stockpile");
                });
#pragma warning restore 612, 618
        }
    }
}
