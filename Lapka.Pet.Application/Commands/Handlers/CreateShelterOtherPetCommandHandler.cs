using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterOtherPetCommandHandler : ICommandHandler<CreateShelterOtherPetCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;

    public CreateShelterOtherPetCommandHandler(IPetRepository petRepository, IShelterRepository shelterRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(CreateShelterOtherPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByUserIdOrWorkerIdAsync(command.PrincipalId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var other = Other.Create(shelter.Id, command.Name, command.Gender, command.DateOfBirth,
            command.IsSterilized, command.Weight);

        await _petRepository.AddPetAsync(other);
        shelter.AddPet(other.Id.Value);
        await _shelterRepository.UpdateAsync(shelter);
    }
}