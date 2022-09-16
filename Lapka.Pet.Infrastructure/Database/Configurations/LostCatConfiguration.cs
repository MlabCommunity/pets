using Lapka.Pet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class LostCatConfiguration : IEntityTypeConfiguration<LostCat>
{
    public void Configure(EntityTypeBuilder<LostCat> builder)
    {
        builder.ToTable("LostCats");
    }
}