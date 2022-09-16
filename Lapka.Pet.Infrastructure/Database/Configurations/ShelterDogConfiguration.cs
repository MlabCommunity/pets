using Lapka.Pet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class ShelterDogConfiguration : IEntityTypeConfiguration<ShelterDog>
{
    public void Configure(EntityTypeBuilder<ShelterDog> builder)
    {
        builder.ToTable("ShelterDogs");
    }
}