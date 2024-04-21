﻿// <auto-generated />
using AlexanderNevskyTemple.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlexanderNevskyTemple.DAL.Migrations
{
    [DbContext(typeof(ANTDbContext))]
    [Migration("20240421111515_InitANTDb")]
    partial class InitANTDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlexanderNevskyTemple.DAL.entities.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CatalogId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("AlexanderNevskyTemple.DAL.entities.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("AlexanderNevskyTemple.DAL.entities.Content", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("AlexanderNevskyTemple.DAL.entities.Article", b =>
                {
                    b.HasOne("AlexanderNevskyTemple.DAL.entities.Catalog", "Catalog")
                        .WithMany("Articles")
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalog");
                });

            modelBuilder.Entity("AlexanderNevskyTemple.DAL.entities.Content", b =>
                {
                    b.HasOne("AlexanderNevskyTemple.DAL.entities.Article", "Article")
                        .WithMany("Contents")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("AlexanderNevskyTemple.DAL.entities.Article", b =>
                {
                    b.Navigation("Contents");
                });

            modelBuilder.Entity("AlexanderNevskyTemple.DAL.entities.Catalog", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
