using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterOtherPetCommandHandler : ICommandHandler<CreateShelterOtherPetCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;

    public CreateShelterOtherPetCommandHandler(IShelterRepository shelterRepository, IUserCacheStorage cacheStorage)
    {
        _shelterRepository = shelterRepository;
        _cacheStorage = cacheStorage;
    }

    public async Task HandleAsync(CreateShelterOtherPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(command.PrincipalId);
        var shelter = await _shelterRepository.FindByIdAsync(shelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var other = new ShelterOther(command.PrincipalId, command.ProfilePhoto, command.Name, command.Gender,
            command.Age, command.IsSterilized, command.Weight, command.Description, shelter.OrganizationName,
            command.IsVisible, shelter.Localization.Longitude, shelter.Localization.Latitude, command.Photos);

        shelter.AddPet(other);
        await _shelterRepository.UpdateAsync(shelter);
    }
}