// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketBooking.Data;

namespace TicketBooking.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211110151543_NeAccount")]
    partial class NeAccount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TicketBooking.Data.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("ActivateCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsUserValid")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Concert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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

                    b.Property<int>("TypeOfConcertID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TypeOfConcertID");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ByTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CashBoxID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConcertID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ConcertID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.TypeOfConcert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AgeLimit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Composer")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("TypeOfConcerts");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Account", b =>
                {
                    b.HasOne("TicketBooking.Data.Models.User", "User")
                        .WithMany("Ticket")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Concert", b =>
                {
                    b.HasOne("TicketBooking.Data.Models.TypeOfConcert", "TypeOfConcert")
                        .WithMany("Concert")
                        .HasForeignKey("TypeOfConcertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfConcert");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Ticket", b =>
                {
                    b.HasOne("TicketBooking.Data.Models.Account", "Account")
                        .WithMany("Ticket")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketBooking.Data.Models.Concert", "Concert")
                        .WithMany("Ticket")
                        .HasForeignKey("ConcertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Account", b =>
                {
                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.Concert", b =>
                {
                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.TypeOfConcert", b =>
                {
                    b.Navigation("Concert");
                });

            modelBuilder.Entity("TicketBooking.Data.Models.User", b =>
                {
                    b.Navigation("Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}
