using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteShelterPetCommandHandler : ICommandHandler<DeleteShelterPetCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;
    private readonly IEventProcessor _eventProcessor; 
        
    public DeleteShelterPetCommandHandler(IShelterRepository shelterRepository, IUserCacheStorage cacheStorage, IEventProcessor eventProcessor)
    {
        _shelterRepository = shelterRepository;
        _cacheStorage = cacheStorage;
        _eventProcessor = eventProcessor;
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

        shelter.RemovePet(command.PetId);

        await _shelterRepository.UpdateAsync(shelter);

        await _eventProcessor.ProcessAsync(shelter.Events);
    }
}