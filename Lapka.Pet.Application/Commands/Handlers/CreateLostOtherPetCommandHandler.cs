using Convey.CQRS.Commands;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateLostOtherPetCommandHandler : ICommandHandler<CreateLostOtherPetCommand>
{
    private readonly ILostPetRepository _repository;
    private readonly IEventProcessor _eventProcessor;

    public CreateLostOtherPetCommandHandler(ILostPetRepository repository, IEventProcessor eventProcessor)
    {
        _repository = repository;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(CreateLostOtherPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var other = new LostOther(command.OwnerId, command.ProfilePhoto, command.Name, command.Gender,
            command.DateOfBirth, command.IsSterilized, command.Weight, command.DateOfDisappearance, command.PhoneNumber,
            command.Longitude, command.Latitude, command.Street, command.City, command.ZipCode, command.IsVisible,
            command.FirstName, command.Description,
            command.Photos);

        await _repository.AddAsync(other);

        await _eventProcessor.ProcessAsync(other.Events);
    }
}