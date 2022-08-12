using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.Repositories;

public interface IPetRepository
{
    Task AddPetAsync(Entities.Pet pet);
    Task<Entities.Pet> FindByIdAsync(Guid id);
    Task UpdateAsync(Entities.Pet pet);
}