﻿// <auto-generated />
using System;
using AirportSystem.Data.DbContests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AirportSystem.Data.Migrations
{
    [DbContext(typeof(AirportSystemDbContext))]
    partial class AirportSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AirportSystem.Domain.Entities.Airplanes.Airplane", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AeroportId")
                        .HasColumnType("bigint");

                    b.Property<string>("Country")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FromToDestination")
                        .HasColumnType("text");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("ToDestination")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AeroportId");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Airports.Airport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<long>("AirplaneId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<long?>("RoleTableId")
                        .HasColumnType("bigint");

                    b.Property<long>("RouleTableId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("RoleTableId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Airports.AirportAirplane", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AeroportId")
                        .HasColumnType("bigint");

                    b.Property<long>("AirplaneId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AeroportId");

                    b.HasIndex("AirplaneId");

                    b.ToTable("AirportAirplanes");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.BlackLists.BlackList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<long>("PassengerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.ToTable("BlackLists");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Employees.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Department")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("PasportNumber")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<long>("PassengerId")
                        .HasColumnType("bigint");

                    b.Property<long>("TicketId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TicketId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Passengers.Passenger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("AgeCategory")
                        .HasColumnType("integer");

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("PassportNumber")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Phone")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Payments.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.RouleTables.RouleTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AirplaneId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FligthStatus")
                        .HasColumnType("integer");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.ToTable("RoulTables");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Tickets.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AeroportId")
                        .HasColumnType("bigint");

                    b.Property<long>("AirplaneId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DayOfFlight")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ItemState")
                        .HasColumnType("integer");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("PassengerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Seat")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AeroportId");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Airplanes.Airplane", b =>
                {
                    b.HasOne("AirportSystem.Domain.Entities.Airports.Airport", "Aeroport")
                        .WithMany()
                        .HasForeignKey("AeroportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeroport");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Airports.Airport", b =>
                {
                    b.HasOne("AirportSystem.Domain.Entities.Airplanes.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportSystem.Domain.Entities.RouleTables.RouleTable", "RouleTable")
                        .WithMany()
                        .HasForeignKey("RoleTableId");

                    b.Navigation("Airplane");

                    b.Navigation("RouleTable");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Airports.AirportAirplane", b =>
                {
                    b.HasOne("AirportSystem.Domain.Entities.Airports.Airport", "Aeroport")
                        .WithMany()
                        .HasForeignKey("AeroportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportSystem.Domain.Entities.Airplanes.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeroport");

                    b.Navigation("Airplane");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.BlackLists.BlackList", b =>
                {
                    b.HasOne("AirportSystem.Domain.Entities.Passengers.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Orders.Order", b =>
                {
                    b.HasOne("AirportSystem.Domain.Entities.Passengers.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportSystem.Domain.Entities.Tickets.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Payments.Payment", b =>
                {
                    b.HasOne("AirportSystem.Domain.Entities.Orders.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.RouleTables.RouleTable", b =>
                {
                    b.HasOne("AirportSystem.Domain.Entities.Airplanes.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");
                });

            modelBuilder.Entity("AirportSystem.Domain.Entities.Tickets.Ticket", b =>
                {
                    b.HasOne("AirportSystem.Domain.Entities.Airports.Airport", "Aeroport")
                        .WithMany()
                        .HasForeignKey("AeroportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportSystem.Domain.Entities.Airplanes.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportSystem.Domain.Entities.Orders.Order", "Order")
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportSystem.Domain.Entities.Passengers.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeroport");

                    b.Navigation("Airplane");

                    b.Navigation("Order");

                    b.Navigation("Passenger");
                });
#pragma warning restore 612, 618
        }
    }
}
