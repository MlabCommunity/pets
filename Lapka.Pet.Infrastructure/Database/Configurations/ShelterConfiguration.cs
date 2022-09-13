using System.Runtime.CompilerServices;
using Lapka.Pet.Core.DomainThings;
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

        var localizationConverter = new ValueConverter<Localization, string>(l => l.ToString(),
            l => Localization.Create(l));

        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new AggregateId(id));
        builder.Property(s => s.Email).HasConversion(x => x.Value, x => new Email(x));
        builder.Property(s => s.ProfilePhotoId).HasConversion(id => id.Value, id => new ProfilePhotoId(id));
        builder.Property(s => s.OrganizationName).HasConversion(name => name.Value, name => new OrganizationName(name));
        builder.Property(s => s.ZipCode).HasConversion(zipCode => zipCode.Value, zipCode => new ZipCode(zipCode));
        builder.Property(s => s.Nip).HasConversion(nip => nip.Value, nip => new Nip(nip));
        builder.Property(s => s.Krs).HasConversion(krs => krs.Value, krs => new Krs(krs));

        builder.HasOne(typeof(Volunteering), "Volunteering");
        builder
            .Property(typeof(Localization), "Localization")
            .HasConversion(localizationConverter)
            .HasColumnName("Localization");

        builder.Property(s => s.Version).IsConcurrencyToken();
        builder.ToTable("Shelters");
    }
}