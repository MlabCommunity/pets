using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Kernel.Abstractions;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateShelterCommandHandler : ICommandHandler<UpdateShelterCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IEventProcessor _eventProcessor;

    public UpdateShelterCommandHandler(IShelterRepository shelterRepository, IEventProcessor eventProcessor)
    {
        _eventProcessor = eventProcessor;
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(UpdateShelterCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdAsync(command.UserId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.Update(command.OrganizationName, command.Longitude, command.Latitude, command.City, command.Street,
            command.ZipCode, command.PhoneNumber, command.Krs,
            command.Nip);

        await _shelterRepository.UpdateAsync(shelter);

        await _eventProcessor.ProcessAsync(shelter.Events);
    }
}