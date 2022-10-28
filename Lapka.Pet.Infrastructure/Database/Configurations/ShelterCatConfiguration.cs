using Lapka.Pet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class ShelterCatConfiguration : IEntityTypeConfiguration<ShelterCat>
{
    public void Configure(EntityTypeBuilder<ShelterCat> builder)
    {
        builder.ToTable("ShelterCats");
    }
}