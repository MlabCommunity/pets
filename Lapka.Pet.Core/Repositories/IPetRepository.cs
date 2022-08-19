using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Repositories;

public interface IPetRepository
{
    Task AddPetAsync(Entities.Pet pet);
    Task<Entities.Pet> FindByIdAsync(AggregateId petId);
    Task UpdateAsync(Entities.Pet pet);
}