using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Contexts;

public interface IPetDbContext
{
    DbSet<Shelter> Shelters { get; set; }
    DbSet<ShelterPet> ShelterPets { get; set; }
    DbSet<Core.Entities.Pet> Pets { get; set; }
    DbSet<Cat> Cats { get; set; }
    DbSet<Dog> Dogs { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}