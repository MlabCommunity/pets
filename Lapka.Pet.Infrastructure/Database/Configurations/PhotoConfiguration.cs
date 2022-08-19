using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class PhotoConfiguration : IEntityTypeConfiguration<PhotoId>
{
    public void Configure(EntityTypeBuilder<PhotoId> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(s => s.Value).HasColumnName("PhotoId");

    }
}