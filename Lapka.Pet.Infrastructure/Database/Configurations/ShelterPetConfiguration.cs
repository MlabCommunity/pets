using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Pet.Infrastructure.Database.Configurations;

internal sealed class ShelterPetConfiguration : IEntityTypeConfiguration<ShelterPet>
{
    public void Configure(EntityTypeBuilder<ShelterPet> builder)
    {
        builder.Property(s => s.OrganizationName).HasConversion(name => name.Value, name => new OrganizationName(name));
        builder.Property(x => x.ShelterId).HasConversion(x => x.Value, x => new ShelterId(x));
        builder.ToTable("ShelterPets");
    }
}