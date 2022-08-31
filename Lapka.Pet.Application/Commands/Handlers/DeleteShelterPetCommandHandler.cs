using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteShelterPetCommandHandler : ICommandHandler<DeleteShelterPetCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IPetRepository _petRepository;
    private readonly IUserCacheStorage _cacheStorage;


    public DeleteShelterPetCommandHandler(IShelterRepository shelterRepository, IPetRepository petRepository,
        IUserCacheStorage cacheStorage)
    {
        _shelterRepository = shelterRepository;
        _petRepository = petRepository;
        _cacheStorage = cacheStorage;
    }


    public async Task HandleAsync(DeleteShelterPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(command.PrincipalId);
        var shelter = await _shelterRepository.FindByIdAsync(shelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var pet = await _petRepository.FindByIdAsync(command.PetId);

        await _petRepository.RemoveAsync(pet);
    }
}