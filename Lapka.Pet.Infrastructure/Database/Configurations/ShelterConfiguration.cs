using System.Runtime.CompilerServices;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(x => x.Value, x => new ShelterId(x));
        builder.Property(s => s.Email).HasConversion(x => x.Value, x => new Email(x));
        builder.Property(s => s.ProfilePhoto).HasConversion(x => x.Value, x => new ProfilePhoto(x));
        builder.Property(s => s.OrganizationName).HasConversion(x => x.Value, x => new OrganizationName(x));
        builder.Property(s => s.Nip).HasConversion(x => x.Value, x => new Nip(x));
        builder.Property(s => s.Krs).HasConversion(x => x.Value, x => new Krs(x));
        builder.Property(s => s.FirstName).HasConversion(x => x.Value, x => new FirstName(x));
        builder.Property(s => s.LastName).HasConversion(x => x.Value, x => new LastName(x));
        builder.Property(s => s.PhoneNumber).HasConversion(x => x.Value, x => new PhoneNumber(x));
        builder.Property(s => s.ZipCode).HasConversion(x => x.Value, x => new ZipCode(x));

        builder.HasMany(x => x.Archives).WithOne(x => x.Shelter).HasForeignKey(x => x.ShelterId);
        builder.HasMany(x => x.Volunteers).WithOne(x => x.Shelter).HasForeignKey(x => x.ShelterId);
        builder.HasMany(x => x.Workers).WithOne(x => x.Shelter).HasForeignKey(x => x.ShelterId);
        builder.HasMany(x => x.ShelterPets).WithOne(x => x.Shelter).HasForeignKey(x => x.ShelterId);
        builder.HasOne(x => x.Volunteering).WithOne(x => x.Shelter);
        builder.Property(s => s.Version).IsConcurrencyToken();

        builder.ToTable("Shelters");
    }
}