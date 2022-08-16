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
        builder.Property(s => s.UserId).HasConversion(id => id.Value, id => new UserId(id));
        builder.Property(s => s.OrganizationName).HasConversion(name => name.Value, name => new OrganizationName(name));

        builder.HasMany(s => s.ShelterPets);

        builder.Property(s => s.Version).IsConcurrencyToken();

        builder.ToTable("Shelters");
    }
}