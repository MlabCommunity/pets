using Lapka.Pet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

public class CatConfiguration : IEntityTypeConfiguration<Cat>
{
    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.Property(s => s.Breed).HasColumnName("cat_bread");
        builder.Property(s => s.Color).HasColumnName("cat_color");
    }
}