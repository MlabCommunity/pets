using Lapka.Pet.Core.Domain;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Core.Entities.Pet>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Pet> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new AggregateId(id));
        builder.Property(s => s.OwnerId).HasConversion(id => id.Value, id => new OwnerId(id));
        
    }
}