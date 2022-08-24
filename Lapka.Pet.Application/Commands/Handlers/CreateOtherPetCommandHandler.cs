using Convey.CQRS.Commands;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateOtherPetCommandHandler : ICommandHandler<CreateOtherPetCommand>
{
    private readonly IPetRepository _petRepository;

    public CreateOtherPetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(CreateOtherPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var other = Other.Create(command.OwnerId, command.Name, command.Gender, command.DateOfBirth,
            command.IsSterilized, command.Weight,command.Photos);

        await _petRepository.AddPetAsync(other);
    }
}