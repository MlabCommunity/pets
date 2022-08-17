using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.Repositories;

public interface IShelterRepository
{
    Task AddAsync(Shelter shelter);
    Task<Shelter> FindByUserIdAsync(Guid userId);
    Task<Shelter> FindByUserIdOrWorkerIdAsync(Guid principalId);
    Task UpdateAsync(Shelter shelter);
    Task DeleteAsync(Shelter shelter);
}