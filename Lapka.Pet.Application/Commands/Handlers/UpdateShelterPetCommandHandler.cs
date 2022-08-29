using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateShelterPetCommandHandler : ICommandHandler<UpdateShelterPetCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;


    public UpdateShelterPetCommandHandler(IPetRepository petRepository, IShelterRepository shelterRepository,
        IUserCacheStorage cacheStorage)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
        _cacheStorage = cacheStorage;
    }


    public async Task HandleAsync(UpdateShelterPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(command.PrincipalId);
        var shelter = await _shelterRepository.FindByIdAsync(shelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var pet = await _petRepository.FindByIdAsync(command.PetId);

        pet.Update(command.Name, command.IsSterilized, command.Weight);

        await _petRepository.UpdateAsync(pet);
    }
}