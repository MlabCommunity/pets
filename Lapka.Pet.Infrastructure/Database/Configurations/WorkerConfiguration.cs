using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.Property<Guid>("Id");

        builder.Property(s => s.WorkerId).HasConversion(id => id.Value, id => new WorkerId(id));

        builder.ToTable("Workers");
    }
}