using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Core.Entities.Pet>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Pet> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new AggregateId(id));
        builder.Property(s => s.OwnerId).HasConversion(id => id.Value, id => new OwnerId(id));
        builder.Property(s => s.Name).HasConversion(name => name.Value, name => new PetName(name));
        builder.Property(s => s.DateOfBirth).HasConversion(dateOfBirth => dateOfBirth.Value,
            dateOfBirth => new DateOfBirth(dateOfBirth));
        builder.Property(s => s.Weight).HasConversion(weight => weight.Value, weight => new Weight(weight));
        builder.HasDiscriminator<string>("Discriminator").HasValue<Other>(PetType.OTHER.ToString())
            .HasValue<Dog>(PetType.DOG.ToString()).HasValue<Cat>(PetType.CAT.ToString());
    }
}