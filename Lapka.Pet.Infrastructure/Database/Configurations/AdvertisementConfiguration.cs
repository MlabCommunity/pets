using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        builder.HasKey(x => x.Id);

        var localizationConverter = new ValueConverter<Localization, string>(l => l.ToString(),
            l => Localization.Create(l));

        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new EntityId(id));
        builder
            .Property(typeof(Localization), "Localization")
            .HasConversion(localizationConverter)
            .HasColumnName("Localization");
    }
}