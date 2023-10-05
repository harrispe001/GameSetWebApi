﻿// <auto-generated />
using System;
using GameSetWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameSetWebApi.Migrations
{
    [DbContext(typeof(GameSetContext))]
    [Migration("20231005044304_teamMigration")]
    partial class teamMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GameSetWebApi.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("GameSetWebApi.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("GameSetWebApi.Models.TeamPerson", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("TeamPersons");
                });

            modelBuilder.Entity("GameSetWebApi.Models.TeamPerson", b =>
                {
                    b.HasOne("GameSetWebApi.Models.Person", "Person")
                        .WithMany("TeamPersons")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameSetWebApi.Models.Team", "Team")
                        .WithMany("TeamPersons")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("GameSetWebApi.Models.Person", b =>
                {
                    b.Navigation("TeamPersons");
                });

            modelBuilder.Entity("GameSetWebApi.Models.Team", b =>
                {
                    b.Navigation("TeamPersons");
                });
#pragma warning restore 612, 618
        }
    }
}
