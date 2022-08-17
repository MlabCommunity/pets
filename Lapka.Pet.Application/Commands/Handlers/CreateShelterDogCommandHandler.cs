using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterDogCommandHandler : ICommandHandler<CreateShelterDogCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;

    public CreateShelterDogCommandHandler(IPetRepository petRepository, IShelterRepository shelterRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(CreateShelterDogCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByUserIdOrWorkerIdAsync(command.PrincipalId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var dog = Dog.Create(shelter.Id, command.Name, command.Gender, command.DateOfBirth, command.IsSterilized,
            command.Weight, command.DogBreed, command.DogColor);

        await _petRepository.AddPetAsync(dog);
        shelter.AddPet(dog.Id.Value);
        await _shelterRepository.UpdateAsync(shelter);
    }
}