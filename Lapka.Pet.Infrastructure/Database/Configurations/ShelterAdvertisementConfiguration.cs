using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class ShelterAdvertisementConfiguration : IEntityTypeConfiguration<ShelterAdvertisement>
{
    public void Configure(EntityTypeBuilder<ShelterAdvertisement> builder)
    {
        builder.Property(s => s.PetId).HasConversion(id => id.Value, id => new PetId(id));
        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new EntityId(id));
        builder.Property(s => s.ShelterId).HasConversion(id => id.Value, id => new ShelterId(id));
        builder.Property(s => s.OrganizationName).HasConversion(name => name.Value, name => new OrganizationName(name));

        builder.ToTable("ShelterAdvertisements");
    }
}