﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking.Data;

#nullable disable

namespace Parking.Migrations
{
    [DbContext(typeof(ParkingContext))]
    partial class ParkingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Parking.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<DateTime>("DateLocation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRetour")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRetourPrevue")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonneId")
                        .HasColumnType("int");

                    b.Property<int>("Tarif")
                        .HasColumnType("int");

                    b.Property<int>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("LocationId");

                    b.HasIndex("PersonneId");

                    b.HasIndex("VoitureId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Parking.Models.Personne", b =>
                {
                    b.Property<int>("PersonneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonneId"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroNin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numerotelephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonneId");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("Parking.Models.Voiture", b =>
                {
                    b.Property<int>("VoitureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoitureId"));

                    b.Property<DateTime>("Annee")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoitureId");

                    b.ToTable("Voiture");
                });

            modelBuilder.Entity("Parking.Models.Location", b =>
                {
                    b.HasOne("Parking.Models.Personne", "Locataire")
                        .WithMany()
                        .HasForeignKey("PersonneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parking.Models.Voiture", "Laviture")
                        .WithMany()
                        .HasForeignKey("VoitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laviture");

                    b.Navigation("Locataire");
                });
#pragma warning restore 612, 618
        }
    }
}
