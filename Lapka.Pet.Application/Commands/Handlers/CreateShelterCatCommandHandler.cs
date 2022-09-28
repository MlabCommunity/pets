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

    public CreateShelterCatCommandHandler(IShelterRepository shelterRepository, IUserCacheStorage cacheStorage)
    {
        _shelterRepository = shelterRepository;
        _cacheStorage = cacheStorage;
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
            command.IsVisible, shelter.Localization.Longitude, shelter.Localization.Latitude,command.CatColor,command.CatBreed,command.Photos);

        shelter.AddPet(cat);

        await _shelterRepository.UpdateAsync(shelter);
    }
}