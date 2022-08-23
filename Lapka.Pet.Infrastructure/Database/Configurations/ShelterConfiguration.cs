using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new AggregateId(id));
        builder.Property(s => s.OrganizationName).HasConversion(name => name.Value, name => new OrganizationName(name));
        builder.Property(s => s.ZipCode).HasConversion(zipCode => zipCode.Value, zipCode => new ZipCode(zipCode));
        builder.Property(s => s.Nip).HasConversion(nip => nip.Value, nip => new Nip(nip));
        builder.Property(s => s.Krs).HasConversion(krs => krs.Value, krs => new Krs(krs));

        builder.HasMany(x => x.Advertisements).WithOne(x => x.Shelter);
        builder.HasOne(typeof(Volunteering), "Volunteering");
        builder.HasMany(typeof(Volunteer), "Volunteers");
        builder.HasMany(typeof(Worker), "Workers");

        builder.Property(s => s.Version).IsConcurrencyToken();

        builder.ToTable("Shelters");
    }
}