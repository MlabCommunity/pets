using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.Repositories;

public interface IPetRepository
{
    Task AddPetAsync(Entities.Pet pet);
}