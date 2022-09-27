using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Repositories;

public interface IShelterRepository
{
    Task AddAsync(Shelter shelter);
    Task<Shelter> FindByIdAsync(ShelterId id);
    Task UpdateAsync(Shelter shelter);
    Task DeleteAsync(Shelter shelter);

}