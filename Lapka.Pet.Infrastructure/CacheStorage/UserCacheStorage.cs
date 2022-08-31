using Lapka.Pet.Application.Services;

namespace Lapka.Pet.Infrastructure.CacheStorage;

internal sealed class UserCacheStorage : IUserCacheStorage
{
    private readonly ICacheStorage _cacheStorage;

    public UserCacheStorage(ICacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
    }

    public void SetPetId(Guid ownerId, Guid petId)
        => _cacheStorage.Set(ownerId.ToString(), petId);

    public Guid GetPetId(Guid ownerId)
        => _cacheStorage.Get<Guid>(ownerId.ToString());

    public void SetShelterId(Guid principalId, Guid shelterId)
        => _cacheStorage.Set(principalId.ToString(), shelterId);

    public Guid GetShelterId(Guid principalId)
        => _cacheStorage.Get<Guid>(principalId.ToString());
}