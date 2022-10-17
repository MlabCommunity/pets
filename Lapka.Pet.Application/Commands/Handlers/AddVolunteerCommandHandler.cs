using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class AddVolunteerCommandHandler : ICommandHandler<AddVolunteerCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IEventProcessor _eventProcessor;

    public AddVolunteerCommandHandler(IShelterRepository shelterRepository, IEventProcessor eventProcessor)
    {
        _shelterRepository = shelterRepository;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(AddVolunteerCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdAsync(command.ShelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.AddVolunteer(command.PrincipalId);
        await _shelterRepository.UpdateAsync(shelter);

        await _eventProcessor.ProcessAsync(shelter.Events);
    }
}