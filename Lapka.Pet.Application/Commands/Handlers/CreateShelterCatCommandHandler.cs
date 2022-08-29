using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterCatCommandHandler : ICommandHandler<CreateShelterCatCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;

    public CreateShelterCatCommandHandler(IPetRepository petRepository, IShelterRepository shelterRepository,
        IUserCacheStorage cacheStorage)
    {
        _petRepository = petRepository;
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

        var cat = Cat.Create(shelter.Id.Value, command.Name, command.Gender, command.DateOfBirth, command.IsSterilized,
            command.Weight, command.CatBreed, command.CatColor, command.Photos);

        await _petRepository.AddPetAsync(cat);
    }
}