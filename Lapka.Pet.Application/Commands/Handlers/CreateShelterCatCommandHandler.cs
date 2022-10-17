using System.Runtime.InteropServices.ComTypes;
using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterCatCommandHandler : ICommandHandler<CreateShelterCatCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;
    private readonly IEventProcessor _eventProcessor;

    public CreateShelterCatCommandHandler(IShelterRepository shelterRepository, IUserCacheStorage cacheStorage, IEventProcessor eventProcessor)
    {
        _shelterRepository = shelterRepository;
        _cacheStorage = cacheStorage;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(CreateShelterCatCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(command.PrincipalId);
        var shelter = await _shelterRepository.FindByIdAsync(shelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var cat = new ShelterCat(command.PrincipalId, command.ProfilePhoto, command.Name, command.Gender,
            command.Age, command.IsSterilized, command.Weight, command.Description, shelter.OrganizationName,
            command.IsVisible, shelter.Localization.Longitude, shelter.Localization.Latitude, shelter.City,
            shelter.Street, shelter.ZipCode,command.CatColor,
            command.CatBreed, command.Photos,shelter);

        shelter.AddPet(cat);

        await _shelterRepository.UpdateAsync(shelter);

        await _eventProcessor.ProcessAsync(shelter.Events);
    }
}