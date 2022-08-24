using Convey.CQRS.Commands;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateLostDogCommandHandler : ICommandHandler<CreateLostDogCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IUserCacheStorage _userCacheStorage;

    public CreateLostDogCommandHandler(IPetRepository petRepository, IUserCacheStorage userCacheStorage)
    {
        _petRepository = petRepository;
        _userCacheStorage = userCacheStorage;
    }

    public async Task HandleAsync(CreateLostDogCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var dog = Dog.Create(command.OwnerId, command.Name, command.Gender, command.DateOfBirth, command.IsSterilized,
            command.Weight, command.DogBreed, command.DogColor);

        await _petRepository.AddPetAsync(dog);
        _userCacheStorage.SetPetId(command.OwnerId, dog.Id);
    }
}