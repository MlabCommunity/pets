using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Repositories;

public interface ILostPetRepository
{
    Task AddAsync(LostPet advertisement);
    Task<LostPet> FindByPetIdAsync(PetId petId);
    Task UpdateAsync(LostPet advertisement);
    Task DeleteAsync(LostPet advertisement);
}