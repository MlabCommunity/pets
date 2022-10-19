using Lapka.Pet.Core.Kernel.Types;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class VisitTypeConfiguration : IEntityTypeConfiguration<VisitType>
{
    public void Configure(EntityTypeBuilder<VisitType> builder)
    {
        builder.Property<Guid>("Id");
        builder.ToTable("VisitTypes");
        builder.Property(x => x.VisitId).HasConversion(x => x.Value, x => new EntityId(x));
        builder.HasOne(x => x.Visit).WithMany(x => x.VisitTypes);
    }
}