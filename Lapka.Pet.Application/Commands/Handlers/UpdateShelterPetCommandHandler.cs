using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateShelterPetCommandHandler : ICommandHandler<UpdateShelterPetCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;


    public UpdateShelterPetCommandHandler(IPetRepository petRepository, IShelterRepository shelterRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }


    public async Task HandleAsync(UpdateShelterPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdOrWorkerIdAsync(command.PrincipalId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var pet = await _petRepository.FindByIdAsync(command.PetId);

        pet.Update(command.Name, command.IsSterilized, command.Weight);

        await _petRepository.UpdateAsync(pet);
    }
}