using Convey.CQRS.Commands;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateDogCommandHandler : ICommandHandler<CreateDogCommand>
{
    private readonly IPetRepository _petRepository;

    public CreateDogCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(CreateDogCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var dog = Dog.Create(command.OwnerId, command.Name, command.Gender, command.DateOfBirth, command.IsSterilized,
            command.Weight, command.DogBreed, command.DogColor);

        await _petRepository.AddPetAsync(dog);
    }
}