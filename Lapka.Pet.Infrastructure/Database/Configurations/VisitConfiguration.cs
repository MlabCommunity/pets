using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitType = Lapka.Pet.Core.ValueObjects.VisitType;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(x => x.VisitId);
        builder.Property(x => x.VisitId).HasConversion(x => x.Value, x => new EntityId(x));
        builder.Property(s => s.WeightOnVisit).HasConversion(weight => weight.Value, weight => new Weight(weight));
        builder.ToTable("Visits");
        builder.HasMany(typeof(VisitType), "VisitTypes");
    }
}