﻿// <auto-generated />
using System;
using System.Collections.Generic;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Migrations
{
    [DbContext(typeof(CoolMusicDbContext))]
    [Migration("20231204143032_GenreWithSpotifyLink")]
    partial class GenreWithSpotifyLink
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.Property<int>("AlbumsId")
                        .HasColumnType("integer");

                    b.Property<int>("ArtistsId")
                        .HasColumnType("integer");

                    b.HasKey("AlbumsId", "ArtistsId");

                    b.HasIndex("ArtistsId");

                    b.ToTable("AlbumArtist");
                });

            modelBuilder.Entity("GenreGenre", b =>
                {
                    b.Property<int>("ParentGenresId")
                        .HasColumnType("integer");

                    b.Property<int>("SubGenresId")
                        .HasColumnType("integer");

                    b.HasKey("ParentGenresId", "SubGenresId");

                    b.HasIndex("SubGenresId");

                    b.ToTable("GenreGenre");
                });

            modelBuilder.Entity("LorenzoVDH.CoolMusicDb.ApplicationCore.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("LorenzoVDH.CoolMusicDb.ApplicationCore.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ArtistName")
                        .HasColumnType("text");

                    b.Property<string>("CountryCode")
                        .HasColumnType("CHAR(2)");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("LorenzoVDH.CoolMusicDb.ApplicationCore.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<string>>("CountryCodes")
                        .HasColumnType("text[]");

                    b.Property<DateOnly?>("DateOfOrigin")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SpotifyTrackPreviewId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.HasOne("LorenzoVDH.CoolMusicDb.ApplicationCore.Entities.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LorenzoVDH.CoolMusicDb.ApplicationCore.Entities.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreGenre", b =>
                {
                    b.HasOne("LorenzoVDH.CoolMusicDb.ApplicationCore.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("ParentGenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LorenzoVDH.CoolMusicDb.ApplicationCore.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("SubGenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
