﻿// <auto-generated />
using System;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220818193449_Dzialaj")]
    partial class Dzialaj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("pets")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("boolean");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Advertisements", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsSterilized")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Pets", "pets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pet");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Shelter", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Krs")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.Property<Guid>("VolunteeringId")
                        .HasColumnType("uuid");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("VolunteeringId");

                    b.ToTable("Shelters", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.PetId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("Value")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ShelterPets", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.PhotoId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("Value")
                        .HasColumnType("uuid")
                        .HasColumnName("PhotoId");

                    b.HasKey("Id");

                    b.ToTable("Photos", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ShelterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Volunteers", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Volunteering", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Volunteerings", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.WorkerId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShelterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Value")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Workers", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Cat", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Pet");

                    b.Property<int>("Breed")
                        .HasColumnType("integer")
                        .HasColumnName("cat_bread");

                    b.Property<int>("Color")
                        .HasColumnType("integer")
                        .HasColumnName("cat_color");

                    b.HasDiscriminator().HasValue("CAT");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Dog", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Pet");

                    b.Property<int>("Breed")
                        .HasColumnType("integer")
                        .HasColumnName("dog_bread");

                    b.Property<int>("Color")
                        .HasColumnType("integer")
                        .HasColumnName("dog_color");

                    b.HasDiscriminator().HasValue("DOG");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Other", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Pet");

                    b.HasDiscriminator().HasValue("OTHER");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.ShelterAdvertisement", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Advertisement");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShelterId")
                        .HasColumnType("uuid");

                    b.HasIndex("ShelterId");

                    b.ToTable("ShelterAdvertisements", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Shelter", b =>
                {
                    b.HasOne("Lapka.Pet.Core.ValueObjects.Volunteering", "Volunteering")
                        .WithMany()
                        .HasForeignKey("VolunteeringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Volunteering");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Volunteer", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Shelter", null)
                        .WithMany("Volunteers")
                        .HasForeignKey("ShelterId");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.WorkerId", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Shelter", "Shelter")
                        .WithMany("Workers")
                        .HasForeignKey("ShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.ShelterAdvertisement", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Advertisement", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.ValueObjects.ShelterAdvertisement", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lapka.Pet.Core.Entities.Shelter", "Shelter")
                        .WithMany("Advertisements")
                        .HasForeignKey("ShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Shelter", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("Volunteers");

                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
