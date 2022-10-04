using Lapka.Pet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

public class ShelterOtherConfiguration : IEntityTypeConfiguration<ShelterOther>
{
    public void Configure(EntityTypeBuilder<ShelterOther> builder)
    {
        builder.ToTable("ShelterOthers");
    }
}