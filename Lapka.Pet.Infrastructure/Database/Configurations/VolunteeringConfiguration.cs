using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class VolunteeringConfiguration : IEntityTypeConfiguration<Volunteering>
{
    public void Configure(EntityTypeBuilder<Volunteering> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(x => x.ShelterId).HasConversion(x => x.Value, x => new ShelterId(x));

        builder.ToTable("Volunteering");
    }
}