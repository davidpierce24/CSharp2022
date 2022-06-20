﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using weddingPlanner.Models;

#nullable disable

namespace weddingPlanner.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220620210925_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("weddingPlanner.Models.Connection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WeddingId")
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("weddingPlanner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("weddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Spouse1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Spouse2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("WeddingId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("weddingPlanner.Models.Connection", b =>
                {
                    b.HasOne("weddingPlanner.Models.User", "User")
                        .WithMany("WeddingsAttending")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("weddingPlanner.Models.Wedding", "Wedding")
                        .WithMany("Attendees")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("weddingPlanner.Models.User", b =>
                {
                    b.Navigation("WeddingsAttending");
                });

            modelBuilder.Entity("weddingPlanner.Models.Wedding", b =>
                {
                    b.Navigation("Attendees");
                });
#pragma warning restore 612, 618
        }
    }
}
