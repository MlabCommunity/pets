using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class RemoveVolunteerCommandHandler : ICommandHandler<RemoveVolunteerCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IEventProcessor _eventProcessor;

    public RemoveVolunteerCommandHandler(IShelterRepository shelterRepository, IEventProcessor eventProcessor)
    {
        _shelterRepository = shelterRepository;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(RemoveVolunteerCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdAsync(command.ShelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.RemoveVolunteer(command.PrincipalId);

        await _shelterRepository.UpdateAsync(shelter);

        await _eventProcessor.ProcessAsync(shelter.Events);
    }
}