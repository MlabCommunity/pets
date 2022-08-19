using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Contexts;

public interface IAppDbContext
{
    DbSet<Shelter> Shelters { get; set; }
    DbSet<PetId> ShelterPets { get; set; }
    DbSet<WorkerId> Workers { get; set; }
    DbSet<Core.Entities.Pet> Pets { get; set; }
    DbSet<Cat> Cats { get; set; }
    DbSet<Dog> Dogs { get; set; }
    DbSet<Volunteering> Volunteerings { get; set; }
    DbSet<Volunteer> Volunteers { get; set; }
    DbSet<ShelterAdvertisement> ShelterAdvertisements { get; set; }
    DbSet<UserAdvertisement> UserAdvertisements { get; set; }
    DbSet<Advertisement> Advertisements { get; set; }
    DbSet<PhotoId> Photos { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}