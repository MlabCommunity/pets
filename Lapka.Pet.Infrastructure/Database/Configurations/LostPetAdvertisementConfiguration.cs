using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class LostPetAdvertisementConfiguration : IEntityTypeConfiguration<LostPetAdvertisement>
{
    public void Configure(EntityTypeBuilder<LostPetAdvertisement> builder)
    {
        builder.Property(s => s.PetId).HasConversion(id => id.Value, id => new PetId(id));
        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new EntityId(id));
        builder.Property(s => s.UserId).HasConversion(id => id.Value, id => new UserId(id));
        builder.Property(s => s.DateOfDisappearance).HasConversion(id => id.Value, id => new DateOfDisappearance(id));
        builder.Property(s => s.PhoneNumber).HasConversion(num => num.Value, num => new PhoneNumber(num));
        builder.Property(s => s.FirstName).HasConversion(name => name.Value, name => new FirstName(name));

        builder.ToTable("LostPetAdvertisements");
    }
}