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

        var dog = new ShelterDog(command.PrincipalId, command.ProfilePhotoId, command.Name, command.Gender,
            command.DateOfBirth, command.IsSterilized, command.Weight, command.Description, shelter.OrganizationName,
            command.IsVisible, shelter.Localization.Longitude, shelter.Localization.Latitude, command.DogBreed,
            command.DogColor);

        shelter.AddPet(dog);
        
        await _shelterRepository.UpdateAsync(shelter);
    }
}