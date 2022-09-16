using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class HideShelterPetCommandHandler : ICommandHandler<HideShelterPetCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;

    public HideShelterPetCommandHandler(IShelterRepository shelterRepository, IUserCacheStorage cacheStorage)
    {
        _shelterRepository = shelterRepository;
        _cacheStorage = cacheStorage;
    }

    public async Task HandleAsync(HideShelterPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(command.PrincipalId);
        var shelter = await _shelterRepository.FindByIdAsync(shelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.HidePet(command.PetId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}