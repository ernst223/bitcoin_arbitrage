﻿// <auto-generated />
using System;
using BitcoinArbitrage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BitcoinArbitrage.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BitcoinArbitrage.Entities.ArbitrageData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCaptured")
                        .HasColumnType("datetime");

                    b.Property<double>("EURZAR")
                        .HasColumnType("double");

                    b.Property<double>("KrakenXBTEUR")
                        .HasColumnType("double");

                    b.Property<double>("LunoXBTZAR")
                        .HasColumnType("double");

                    b.Property<double>("PercentageProfitBeforeCost")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("arbitrageData");
                });
#pragma warning restore 612, 618
        }
    }
}