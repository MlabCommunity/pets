using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class ArchiveConfiguration : IEntityTypeConfiguration<Archive>
{
    public void Configure(EntityTypeBuilder<Archive> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(x => x.ShelterId).HasConversion(x => x.Value, x => new ShelterId(x));
        
        builder.Property(x => x.PetId).HasConversion(x => x.Value, x => new PetId(x));
    }
}