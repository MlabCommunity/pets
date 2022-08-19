using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(s => s.UserId).HasConversion(entityId => entityId.Value, entityId => new UserId(entityId));
        builder.Property(s => s.Email).HasConversion(email => email.Value, email => new Email(email));
        builder.ToTable("Volunteers");
    }
}