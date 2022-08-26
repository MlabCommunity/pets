using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteShelterPetCommandHandler : ICommandHandler<DeleteShelterPetCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IPetRepository _petRepository;


    public DeleteShelterPetCommandHandler(IShelterRepository shelterRepository, IPetRepository petRepository)
    {
        _shelterRepository = shelterRepository;
        _petRepository = petRepository;
    }


    public async Task HandleAsync(DeleteShelterPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdOrWorkerIdAsync(command.PrincipalId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var pet = await _petRepository.FindByIdAsync(command.PetId);

        await _petRepository.RemoveAsync(pet);
    }
}