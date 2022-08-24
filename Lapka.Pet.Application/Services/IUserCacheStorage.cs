namespace Lapka.Pet.Application.Services;

public interface IUserCacheStorage
{
    void SetPetId(Guid ownerId, Guid petId);
    Guid GetPetId(Guid ownerId);
}