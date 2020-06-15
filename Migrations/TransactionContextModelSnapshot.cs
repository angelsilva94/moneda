﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using moneda;

namespace moneda.Migrations
{
    [DbContext(typeof(TransactionContext))]
    partial class TransactionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("moneda.Charge", b =>
                {
                    b.Property<int>("ChargeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ChargeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.Property<int>("currency")
                        .HasColumnType("int");

                    b.HasKey("ChargeId");

                    b.HasIndex("UserId");

                    b.ToTable("Charges");

                    b.HasData(
                        new
                        {
                            ChargeId = 1,
                            ChargeDate = new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            amount = 100.0,
                            currency = 0
                        },
                        new
                        {
                            ChargeId = 2,
                            ChargeDate = new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            amount = 200.0,
                            currency = 1
                        },
                        new
                        {
                            ChargeId = 3,
                            ChargeDate = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            amount = 200.0,
                            currency = 0
                        },
                        new
                        {
                            ChargeId = 4,
                            ChargeDate = new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            amount = 300.0,
                            currency = 1
                        },
                        new
                        {
                            ChargeId = 5,
                            ChargeDate = new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3,
                            amount = 50.0,
                            currency = 0
                        },
                        new
                        {
                            ChargeId = 6,
                            ChargeDate = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3,
                            amount = 187.0,
                            currency = 1
                        },
                        new
                        {
                            ChargeId = 7,
                            ChargeDate = new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 4,
                            amount = 176.0,
                            currency = 0
                        },
                        new
                        {
                            ChargeId = 8,
                            ChargeDate = new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 4,
                            amount = 60.0,
                            currency = 1
                        },
                        new
                        {
                            ChargeId = 9,
                            ChargeDate = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 5,
                            amount = 12.0,
                            currency = 0
                        },
                        new
                        {
                            ChargeId = 10,
                            ChargeDate = new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 5,
                            amount = 100.0,
                            currency = 1
                        });
                });

            modelBuilder.Entity("moneda.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1
                        },
                        new
                        {
                            UserId = 2
                        },
                        new
                        {
                            UserId = 3
                        },
                        new
                        {
                            UserId = 4
                        },
                        new
                        {
                            UserId = 5
                        });
                });

            modelBuilder.Entity("moneda.Charge", b =>
                {
                    b.HasOne("moneda.User", "Transaction")
                        .WithMany("Charges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}