using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterDogCommandHandler : ICommandHandler<CreateShelterDogCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;

    public CreateShelterDogCommandHandler(IPetRepository petRepository, IShelterRepository shelterRepository,
        IUserCacheStorage userCacheStorage)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
        _cacheStorage = userCacheStorage;
    }

    public async Task HandleAsync(CreateShelterDogCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(command.PrincipalId);
        var shelter = await _shelterRepository.FindByIdAsync(shelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var dog = Dog.Create(shelter.Id.Value, command.Name, command.Gender, command.DateOfBirth, command.IsSterilized,
            command.Weight, command.DogBreed, command.DogColor, command.Photos);

        await _petRepository.AddPetAsync(dog);
    }
}