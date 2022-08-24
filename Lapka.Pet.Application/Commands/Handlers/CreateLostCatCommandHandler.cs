using Convey.CQRS.Commands;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateLostCatCommandHandler : ICommandHandler<CreateLostCatCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IUserCacheStorage _userCacheStorage;

    public CreateLostCatCommandHandler(IPetRepository petRepository, IUserCacheStorage userCacheStorage)
    {
        _petRepository = petRepository;
        _userCacheStorage = userCacheStorage;
    }

    public async Task HandleAsync(CreateLostCatCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var cat = Cat.Create(command.OwnerId, command.Name, command.Gender, command.DateOfBirth, command.IsSterilized,
            command.Weight, command.CatBreed, command.CatColor);

        await _petRepository.AddPetAsync(cat);
        _userCacheStorage.SetPetId(command.OwnerId, cat.Id);
    }
}