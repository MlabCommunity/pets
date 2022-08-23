using Convey.CQRS.Commands;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.CacheStorage;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateLostOtherPetCommandHandler : ICommandHandler<CreateLostOtherPetCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IUserCacheStorage _userCacheStorage;

    public CreateLostOtherPetCommandHandler(IPetRepository petRepository, IUserCacheStorage userCacheStorage)
    {
        _petRepository = petRepository;
        _userCacheStorage = userCacheStorage;
    }

    public async Task HandleAsync(CreateLostOtherPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var other = Other.Create(command.OwnerId, command.Name, command.Gender, command.DateOfBirth,
            command.IsSterilized,
            command.Weight);

        await _petRepository.AddPetAsync(other);
        _userCacheStorage.SetPetId(command.OwnerId, other.Id);
    }
}