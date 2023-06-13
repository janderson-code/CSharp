﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetoAnime.Anime.API.Data;

#nullable disable

namespace ProjetoAnime.Anime.API.Migrations
{
    [DbContext(typeof(AnimeDbContext))]
    partial class AnimeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjetoAnime.Anime.API.Models.Anime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeOriginal")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Animes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
