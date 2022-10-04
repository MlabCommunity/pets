using Lapka.Pet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class OtherConfiguration : IEntityTypeConfiguration<Other>
{
    public void Configure(EntityTypeBuilder<Other> builder)
    {
        builder.ToTable("Others");
    }
}