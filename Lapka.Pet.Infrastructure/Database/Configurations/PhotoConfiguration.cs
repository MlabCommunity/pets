using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.Property<Guid>("Id");

        builder.Property(x => x.PetId).HasConversion(x => x.Value, x => new PetId(x));
        builder.Property(s => s.Link).HasConversion(x => x.Value, x => new PhotoLink(x));
    }
}