using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class PublishShelterAdvertisementCommandHandler : ICommandHandler<PublishShelterPetCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;

    public PublishShelterAdvertisementCommandHandler(IShelterRepository shelterRepository,
        IUserCacheStorage cacheStorage)
    {
        _shelterRepository = shelterRepository;
        _cacheStorage = cacheStorage;
    }

    public async Task HandleAsync(PublishShelterPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(command.PrincipalId);
        var shelter = await _shelterRepository.FindByIdAsync(shelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.PublishPet(command.PetId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}