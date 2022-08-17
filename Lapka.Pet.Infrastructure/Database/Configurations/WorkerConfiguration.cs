using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class WorkerConfiguration : IEntityTypeConfiguration<WorkerId>
{
    public void Configure(EntityTypeBuilder<WorkerId> builder)
    {
        builder.Property<Guid>("Id");

        builder.Property(s => s.Value);
        builder.ToTable("Workers");
    }
}