namespace Lapka.Pet.Infrastructure.CacheStorage;

public interface IUserCacheStorage
{
    void SetPetId(Guid ownerId, Guid petId);
    Guid GetPetId(Guid ownerId);
}