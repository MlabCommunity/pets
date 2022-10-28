using Lapka.Pet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

public class LostOtherConfiguration : IEntityTypeConfiguration<LostOther>
{
    public void Configure(EntityTypeBuilder<LostOther> builder)
    {
        builder.ToTable("LostOthers");
    }
}