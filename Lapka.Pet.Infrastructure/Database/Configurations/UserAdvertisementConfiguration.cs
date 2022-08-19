using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class UserAdvertisementConfiguration : IEntityTypeConfiguration<UserAdvertisement>
{
    public void Configure(EntityTypeBuilder<UserAdvertisement> builder)
    {
        builder.Property(s => s.PetId).HasConversion(id => id.Value, id => new PetId(id));
        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new EntityId(id));
        builder.Property(s => s.DateOfDisappearance).HasConversion(id => id.Value, id => new DateOfDisappearance(id));
        
        builder.ToTable("UserAdvertisements");
    }
}