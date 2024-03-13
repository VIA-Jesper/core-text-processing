﻿// <auto-generated />
using DistinctWebAPI.Controllers;
using DistinctWebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DistinctWebAPI.Migrations
{
    [DbContext(typeof(TextDbContext))]
    [Migration("20240309154955_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DistinctWebAPI.Models.DistinctWord", b =>
                {
                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Text");

                    b.ToTable("UniqueWords");
                });

            modelBuilder.Entity("DistinctWebAPI.Models.WatchlistWord", b =>
                {
                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Word");

                    b.ToTable("Watchlist");
                });
#pragma warning restore 612, 618
        }
    }
}
