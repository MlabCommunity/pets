using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class ShelterPetConfiguration : IEntityTypeConfiguration<PetId>
{
    public void Configure(EntityTypeBuilder<PetId> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(s => s.Value);
        builder.ToTable("ShelterPets");
    }
}