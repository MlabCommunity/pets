using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class PetConfiguration : IEntityTypeConfiguration<Core.Entities.Pet>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Pet> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(id => id.Value, id => new PetId(id));
        builder.Property(s => s.OwnerId).HasConversion(id => id.Value, id => new OwnerId(id));
        builder.Property(s => s.ProfilePhoto).HasConversion(id => id.Value, id => new ProfilePhoto(id));

        builder.Property(s => s.Name).HasConversion(name => name.Value, name => new PetName(name));
        builder.Property(s => s.DateOfBirth).HasConversion(dateOfBirth => dateOfBirth.Value,
            dateOfBirth => new DateOfBirth(dateOfBirth));
        builder.Property(s => s.Weight).HasConversion(weight => weight.Value, weight => new Weight(weight));

        builder.HasMany(x => x.Likes).WithOne(x => x.Pet).HasForeignKey(x=>x.PetId);
        builder.HasMany(x => x.Photos).WithOne(x => x.Pet).HasForeignKey(x=>x.PetId);
        builder.HasMany(x => x.Visits).WithOne(x => x.Pet).HasForeignKey(x=>x.PetId);
        
        builder.Property(s => s.Version).IsConcurrencyToken();
       // builder.ToTable("Pets");
    }
}