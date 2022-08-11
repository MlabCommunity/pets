using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

public class ShelterPetConfiguration : IEntityTypeConfiguration<ShelterPet>
{
    public void Configure(EntityTypeBuilder<ShelterPet> builder)
    {
        builder.Property<Guid>("Id");

        builder.Property(s => s.PetId).HasConversion(s => s.Value, id => new PetId(id));

        builder.ToTable("ShelterPets");
    }
}