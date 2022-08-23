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
}