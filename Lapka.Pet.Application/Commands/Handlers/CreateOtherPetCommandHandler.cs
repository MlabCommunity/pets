using Convey.CQRS.Commands;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateOtherPetCommandHandler : ICommandHandler<CreateOtherPetCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IEventProcessor _eventProcessor;

    public CreateOtherPetCommandHandler(IPetRepository petRepository, IEventProcessor eventProcessor)
    {
        _petRepository = petRepository;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(CreateOtherPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var other = Other.Create(command.OwnerId, command.ProfilePhotoId, command.Name, command.Gender,
            command.DateOfBirth,
            command.IsSterilized, command.Weight, command.Photos);

        await _petRepository.AddAsync(other);

        await _eventProcessor.ProcessAsync(other.Events);
    }
}