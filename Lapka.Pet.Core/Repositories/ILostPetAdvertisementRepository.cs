using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Repositories;

public interface ILostPetAdvertisementRepository
{
    Task AddAsync(LostPetAdvertisement advertisement);
    Task<LostPetAdvertisement> FindByPetIdAsync(PetId petId);
    Task<LostPetAdvertisement> FindByIdAsync(EntityId EntityId);
    Task UpdateAsync(LostPetAdvertisement advertisement);
    Task DeleteAsync(LostPetAdvertisement advertisement);
}