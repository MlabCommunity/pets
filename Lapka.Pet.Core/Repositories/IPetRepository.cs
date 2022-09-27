using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Repositories;

public interface IPetRepository
{
    Task AddPetAsync(Entities.Pet pet);
    Task<Entities.Pet> FindByIdAsync(PetId petId);
    Task UpdateAsync(Entities.Pet pet);
    Task RemoveAsync(Entities.Pet pet);

}