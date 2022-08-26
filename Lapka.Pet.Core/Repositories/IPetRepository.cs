using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.Repositories;

public interface IPetRepository
{
    Task AddPetAsync(Entities.Pet pet);
    Task<Entities.Pet> FindByIdAsync(AggregateId petId);
    Task UpdateAsync(Entities.Pet pet);
    Task RemoveAsync(Entities.Pet pet);
    Task RemoveByIdAsync(AggregateId petId);
}