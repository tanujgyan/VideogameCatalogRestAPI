﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideogameCatalogRestAPI.DBContext;

namespace VideogameCatalogRestAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210321020330_AddVideogametoDB")]
    partial class AddVideogametoDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VideogameCatalogRestAPI.Entities.Videogame", b =>
                {
                    b.Property<int>("VideogameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genere")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VideogameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VideogameId");

                    b.ToTable("Videogames");
                });
#pragma warning restore 612, 618
        }
    }
}
