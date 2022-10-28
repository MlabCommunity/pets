using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(x => x.PetId).HasConversion(x => x.Value, x => new PetId(x));
        builder.Property(x => x.UserId).HasConversion(x => x.Value, x => new UserId(x));
    }
}