namespace Lapka.Pet.Application.Services;

public interface IUserCacheStorage
{
    void SetPetId(Guid ownerId, Guid petId);
    Guid GetPetId(Guid ownerId);

    void SetShelterId(Guid principalId, Guid shelterId);
    Guid GetShelterId(Guid principalId);
}