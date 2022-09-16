using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class LocalizationConfiguration : IEntityTypeConfiguration<Localization>
{
    public void Configure(EntityTypeBuilder<Localization> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(x => x.Latitude).HasConversion(x => x.Value, x => new Latitude(x));
        builder.Property(x => x.Longitude).HasConversion(x => x.Value, x => new Longitude(x));

        
    }
}