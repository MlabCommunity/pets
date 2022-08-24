using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Repositories;

public interface IShelterAdvertisementRepository
{
    Task<ShelterAdvertisement> FindByShelterIdAsync(ShelterId id);
    Task UpdateAsync(ShelterAdvertisement shelterAdvertisement);
    Task DeleteAsync(ShelterAdvertisement shelterAdvertisement);
}