using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.Property<Guid>("Id");
        //   builder.HasIndex(x => x.WorkerId).IsUnique();
        builder.Property(s => s.WorkerId).HasConversion(id => id.Value, id => new WorkerId(id));
        builder.Property(s => s.FirstName).HasConversion(id => id.Value, id => new FirstName(id));
        builder.Property(s => s.LastName).HasConversion(id => id.Value, id => new LastName(id));
        builder.Property(s => s.Email).HasConversion(id => id.Value, id => new Email(id));
        builder.Property(s => s.WorkerId).HasConversion(id => id.Value, id => new WorkerId(id));

        builder.ToTable("Workers");
    }
}