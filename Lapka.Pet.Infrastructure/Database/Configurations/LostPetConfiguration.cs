using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class LostPetAdvertisementConfiguration : IEntityTypeConfiguration<LostPet>
{
    public void Configure(EntityTypeBuilder<LostPet> builder)
    {
        builder.Property(s => s.OwnerId).HasConversion(id => id.Value, id => new OwnerId(id));
        builder.Property(s => s.DateOfDisappearance).HasConversion(id => id.Value, id => new DateOfDisappearance(id));
        builder.Property(s => s.PhoneNumber).HasConversion(num => num.Value, num => new PhoneNumber(num));
        builder.Property(s => s.FirstName).HasConversion(name => name.Value, name => new FirstName(name));
        
        builder.ToTable("LostPet");
    }
}