// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using manyToManyLecture.Models;

#nullable disable

namespace manyToManyLecture.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220617153534_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("manyToManyLecture.Models.Actor", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MovieId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("manyToManyLecture.Models.CastList", b =>
                {
                    b.Property<int>("CastListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CastListId");

                    b.HasIndex("ActorId");

                    b.HasIndex("MovieId");

                    b.ToTable("CastList");
                });

            modelBuilder.Entity("manyToManyLecture.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("manyToManyLecture.Models.CastList", b =>
                {
                    b.HasOne("manyToManyLecture.Models.Actor", "Actor")
                        .WithMany("MoviesActerIn")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("manyToManyLecture.Models.Movie", "Movie")
                        .WithMany("ActorsInMovie")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("manyToManyLecture.Models.Actor", b =>
                {
                    b.Navigation("MoviesActerIn");
                });

            modelBuilder.Entity("manyToManyLecture.Models.Movie", b =>
                {
                    b.Navigation("ActorsInMovie");
                });
#pragma warning restore 612, 618
        }
    }
}
