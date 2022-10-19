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
    [Migration("20221019112110_siema")]
    partial class siema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("pets")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsSterilized")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.Property<double?>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Pets", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Shelter", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Krs")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<Guid?>("LocalizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nip")
                        .HasColumnType("text");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocalizationId");

                    b.ToTable("Shelters", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Visit", b =>
                {
                    b.Property<Guid>("VisitId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfVisit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("HasTookPlace")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PetId")
                        .HasColumnType("uuid");

                    b.Property<double?>("WeightOnVisit")
                        .HasColumnType("double precision");

                    b.HasKey("VisitId");

                    b.HasIndex("PetId");

                    b.ToTable("Visits", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Archive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PetId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ShelterId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Archives", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PetId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Likes", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Localization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Localization", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<Guid?>("PetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Photos", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.VisitType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("VisitId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("VisitTypes", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ShelterId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
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

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("text");

                    b.Property<string>("DailyHelpDescription")
                        .HasColumnType("text");

                    b.Property<string>("DonationDescription")
                        .HasColumnType("text");

                    b.Property<bool>("IsDailyHelpActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDonationActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTakingDogsOutActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ShelterId")
                        .HasColumnType("uuid");

                    b.Property<string>("TakingDogsOutDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId")
                        .IsUnique();

                    b.ToTable("Volunteering", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CratedAt");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<Guid?>("ShelterId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WorkerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Workers", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Cat", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Pet");

                    b.Property<int>("Breed")
                        .HasColumnType("integer");

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.ToTable("Cats", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Dog", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Pet");

                    b.Property<int>("Breed")
                        .HasColumnType("integer");

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.ToTable("Dogs", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.LostPet", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Pet");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateOfDisappearance")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LocalizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasIndex("LocalizationId");

                    b.ToTable("LostPet", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Other", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Pet");

                    b.ToTable("Others", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.ShelterPet", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.Pet");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LocalizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("text");

                    b.Property<Guid?>("ShelterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasIndex("LocalizationId");

                    b.HasIndex("ShelterId");

                    b.ToTable("ShelterPets", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.LostCat", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.LostPet");

                    b.Property<int>("CatBreed")
                        .HasColumnType("integer");

                    b.Property<int>("CatColor")
                        .HasColumnType("integer");

                    b.ToTable("LostCats", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.LostDog", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.LostPet");

                    b.Property<int>("DogBreed")
                        .HasColumnType("integer");

                    b.Property<int>("DogColor")
                        .HasColumnType("integer");

                    b.ToTable("LostDogs", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.LostOther", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.LostPet");

                    b.ToTable("LostOthers", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.ShelterCat", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.ShelterPet");

                    b.Property<int>("Breed")
                        .HasColumnType("integer");

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.ToTable("ShelterCats", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.ShelterDog", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.ShelterPet");

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.Property<int>("DogBreed")
                        .HasColumnType("integer");

                    b.ToTable("ShelterDogs", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.ShelterOther", b =>
                {
                    b.HasBaseType("Lapka.Pet.Core.Entities.ShelterPet");

                    b.ToTable("ShelterOthers", "pets");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Shelter", b =>
                {
                    b.HasOne("Lapka.Pet.Core.ValueObjects.Localization", "Localization")
                        .WithMany()
                        .HasForeignKey("LocalizationId");

                    b.Navigation("Localization");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Visit", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Pet", "Pet")
                        .WithMany("Visits")
                        .HasForeignKey("PetId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Archive", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Shelter", "Shelter")
                        .WithMany("Archives")
                        .HasForeignKey("ShelterId");

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Like", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Pet", "Pet")
                        .WithMany("Likes")
                        .HasForeignKey("PetId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Photo", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Pet", "Pet")
                        .WithMany("Photos")
                        .HasForeignKey("PetId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.VisitType", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Visit", "Visit")
                        .WithMany("VisitTypes")
                        .HasForeignKey("VisitId");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Volunteer", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Shelter", "Shelter")
                        .WithMany("Volunteers")
                        .HasForeignKey("ShelterId");

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Volunteering", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Shelter", "Shelter")
                        .WithOne("Volunteering")
                        .HasForeignKey("Lapka.Pet.Core.ValueObjects.Volunteering", "ShelterId");

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("Lapka.Pet.Core.ValueObjects.Worker", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Shelter", "Shelter")
                        .WithMany("Workers")
                        .HasForeignKey("ShelterId");

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Cat", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Pet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.Cat", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Dog", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Pet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.Dog", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.LostPet", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Pet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.LostPet", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lapka.Pet.Core.ValueObjects.Localization", "Localization")
                        .WithMany()
                        .HasForeignKey("LocalizationId");

                    b.Navigation("Localization");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Other", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Pet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.Other", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.ShelterPet", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.Pet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.ShelterPet", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lapka.Pet.Core.ValueObjects.Localization", "Localization")
                        .WithMany()
                        .HasForeignKey("LocalizationId");

                    b.HasOne("Lapka.Pet.Core.Entities.Shelter", "Shelter")
                        .WithMany("ShelterPets")
                        .HasForeignKey("ShelterId");

                    b.Navigation("Localization");

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.LostCat", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.LostPet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.LostCat", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.LostDog", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.LostPet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.LostDog", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.LostOther", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.LostPet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.LostOther", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.ShelterCat", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.ShelterPet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.ShelterCat", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.ShelterDog", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.ShelterPet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.ShelterDog", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.ShelterOther", b =>
                {
                    b.HasOne("Lapka.Pet.Core.Entities.ShelterPet", null)
                        .WithOne()
                        .HasForeignKey("Lapka.Pet.Core.Entities.ShelterOther", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Pet", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Photos");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Shelter", b =>
                {
                    b.Navigation("Archives");

                    b.Navigation("ShelterPets");

                    b.Navigation("Volunteering");

                    b.Navigation("Volunteers");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("Lapka.Pet.Core.Entities.Visit", b =>
                {
                    b.Navigation("VisitTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
