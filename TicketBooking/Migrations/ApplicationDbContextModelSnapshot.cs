﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketBooking.Data;

namespace TicketBooking.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketBooking.Data.Models.Concert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountOfTicket")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfConcert")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExectorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationOfConcert")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CashBoxID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConcertID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ConcertID");

                    b.HasIndex("UserID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.TypeOfConcert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeLimit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Composer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConcertID")
                        .HasColumnType("int");

                    b.Property<string>("Healiner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfConcert")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfThisConcert")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfVoice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Way")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ConcertID");

                    b.ToTable("TypeOfConcerts");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Ticket", b =>
                {
                    b.HasOne("TicketBooking.Data.Models.Concert", "Concert")
                        .WithMany("Ticket")
                        .HasForeignKey("ConcertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketBooking.Data.Models.User", "User")
                        .WithMany("Ticket")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.TypeOfConcert", b =>
                {
                    b.HasOne("TicketBooking.Data.Models.Concert", "Concert")
                        .WithMany("TypeOfConcert")
                        .HasForeignKey("ConcertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Concert", b =>
                {
                    b.Navigation("Ticket");

                    b.Navigation("TypeOfConcert");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.User", b =>
                {
                    b.Navigation("Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}