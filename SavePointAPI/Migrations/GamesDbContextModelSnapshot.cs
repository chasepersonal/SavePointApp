﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SavePointAPI.Data;

namespace SavePointAPI.Migrations
{
    [DbContext(typeof(GamesDbContext))]
    partial class GamesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("SavePointAPI.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Console");

                    b.Property<string>("Genre");

                    b.Property<int>("Rating");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SavePointAPI.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<bool>("IsCurrent");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ProfilePhotos");
                });

            modelBuilder.Entity("SavePointAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FavoriteGames");

                    b.Property<string>("FavoriteGenres");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("KnownAs");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("State");

                    b.Property<string>("Summary");

                    b.Property<string>("Username");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SavePointAPI.Models.Games", b =>
                {
                    b.HasOne("SavePointAPI.Models.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SavePointAPI.Models.Photo", b =>
                {
                    b.HasOne("SavePointAPI.Models.User", "User")
                        .WithMany("ProfilePhotos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
