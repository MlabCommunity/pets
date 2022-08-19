using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Repositories;

public interface IUserAdvertisementRepository
{
    Task AddAsync(UserAdvertisement advertisement);
    Task<UserAdvertisement> FindByPetIdAsync(PetId petId);
    Task<UserAdvertisement> FindByIdAsync(EntityId EntityId);
    Task UpdateAsync(UserAdvertisement advertisement);
    Task DeleteAsync(UserAdvertisement advertisement);
}