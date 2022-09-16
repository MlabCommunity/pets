using Lapka.Pet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class LostDogConfiguration : IEntityTypeConfiguration<LostDog>
{
    public void Configure(EntityTypeBuilder<LostDog> builder)
    {
        builder.ToTable("LostDogs");
    }
}