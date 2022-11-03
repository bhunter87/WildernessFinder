﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WildernessFinder.Models;

#nullable disable

namespace WildernessFinder.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WildernessFinder.Models.LatLng", b =>
                {
                    b.Property<int>("LatLngId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Lat")
                        .HasColumnType("float");

                    b.Property<float>("Lng")
                        .HasColumnType("float");

                    b.HasKey("LatLngId");

                    b.ToTable("LatLng");
                });

            modelBuilder.Entity("WildernessFinder.Models.NationalPark", b =>
                {
                    b.Property<int>("NationalParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LatLngId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("NationalParkId");

                    b.HasIndex("LatLngId");

                    b.ToTable("NationalParks");
                });

            modelBuilder.Entity("WildernessFinder.Models.StatePark", b =>
                {
                    b.Property<int>("StateParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LatLngId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StateParkId");

                    b.HasIndex("LatLngId");

                    b.ToTable("StateParks");
                });

            modelBuilder.Entity("WildernessFinder.Models.NationalPark", b =>
                {
                    b.HasOne("WildernessFinder.Models.LatLng", "LatLng")
                        .WithMany()
                        .HasForeignKey("LatLngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LatLng");
                });

            modelBuilder.Entity("WildernessFinder.Models.StatePark", b =>
                {
                    b.HasOne("WildernessFinder.Models.LatLng", "LatLng")
                        .WithMany()
                        .HasForeignKey("LatLngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LatLng");
                });
#pragma warning restore 612, 618
        }
    }
}
