using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateDogCommandHandler : ICommandHandler<CreateDogCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IEventProcessor _eventProcessor;

    public CreateDogCommandHandler(IPetRepository petRepository, IEventProcessor eventProcessor)
    {
        _petRepository = petRepository;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(CreateDogCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var dog = Dog.Create(command.OwnerId, command.ProfilePhotoId, command.Name, command.Gender, command.DateOfBirth,
            command.IsSterilized,
            command.Weight, command.DogBreed, command.DogColor, command.Photos);

        await _petRepository.AddPetAsync(dog);

        await _eventProcessor.ProcessAsync(dog.Events);
    }
}