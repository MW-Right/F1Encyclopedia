﻿// <auto-generated />
using System;
using F1Encyclopedia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace F1Encyclopedia.Migrations
{
    [DbContext(typeof(F1EncyclopediaContext))]
    [Migration("20210210150300_TracksAddLocationInfo")]
    partial class TracksAddLocationInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Common.Colour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Hex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConstructorId");

                    b.ToTable("Colours");
                });

            modelBuilder.Entity("Data.Models.Common.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Continent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Data.Models.Common.RaceWeekend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("RaceWeekends");
                });

            modelBuilder.Entity("Data.Models.ConstructorTeams.Constructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleSponsor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Constructors");
                });

            modelBuilder.Entity("Data.Models.ConstructorTeams.PersonRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConstructorId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("PersonRoles");
                });

            modelBuilder.Entity("Data.Models.Drivers.DriverInformation", b =>
                {
                    b.Property<int>("DriverInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Awareness")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<bool>("DaddysCash")
                        .HasColumnType("bit");

                    b.Property<int>("Experience")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<int>("Pace")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Racecraft")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.HasKey("DriverInformationId");

                    b.ToTable("DriverInformations");
                });

            modelBuilder.Entity("Data.Models.Drivers.DriverRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RaceWeekendId")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RaceWeekendId");

                    b.ToTable("DriverRatings");
                });

            modelBuilder.Entity("F1Encyclopedia.Data.Models.Common.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DoB")
                        .HasColumnName("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverInformationId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverInformationId")
                        .IsUnique();

                    b.HasIndex("NationalityId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("F1Encyclopedia.Data.Models.Tracks.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Alt")
                        .HasColumnName("Altitude")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<float>("Lat")
                        .HasColumnName("Lattitude")
                        .HasColumnType("real");

                    b.Property<float>("Long")
                        .HasColumnName("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<string>("WikiUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Data.Models.Common.Colour", b =>
                {
                    b.HasOne("Data.Models.ConstructorTeams.Constructor", "Constructor")
                        .WithMany("TeamColours")
                        .HasForeignKey("ConstructorId");
                });

            modelBuilder.Entity("Data.Models.Common.RaceWeekend", b =>
                {
                    b.HasOne("F1Encyclopedia.Data.Models.Tracks.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.ConstructorTeams.Constructor", b =>
                {
                    b.HasOne("Data.Models.Common.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.ConstructorTeams.PersonRole", b =>
                {
                    b.HasOne("Data.Models.ConstructorTeams.Constructor", "Constructor")
                        .WithMany("Staff")
                        .HasForeignKey("ConstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("F1Encyclopedia.Data.Models.Common.Person", "Employee")
                        .WithMany("Teams")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Models.Common.RaceWeekend", "From")
                        .WithMany()
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Data.Models.Common.RaceWeekend", "To")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.Drivers.DriverRating", b =>
                {
                    b.HasOne("F1Encyclopedia.Data.Models.Common.Person", "Driver")
                        .WithMany("DriverRatings")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Models.Common.RaceWeekend", "RaceWeekend")
                        .WithMany()
                        .HasForeignKey("RaceWeekendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("F1Encyclopedia.Data.Models.Common.Person", b =>
                {
                    b.HasOne("Data.Models.Drivers.DriverInformation", "DriverInformation")
                        .WithOne("Driver")
                        .HasForeignKey("F1Encyclopedia.Data.Models.Common.Person", "DriverInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Common.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("F1Encyclopedia.Data.Models.Tracks.Track", b =>
                {
                    b.HasOne("Data.Models.Common.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
