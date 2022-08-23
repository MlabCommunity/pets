using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.Repositories;

public interface IShelterRepository
{
    Task AddAsync(Shelter shelter);
    Task<Shelter> FindByIdAsync(AggregateId Id);
    Task<Shelter> FindByIdOrWorkerIdAsync(Guid principalId);
    Task UpdateAsync(Shelter shelter);
    Task DeleteAsync(Shelter shelter);
}