using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateShelterCommandHandler : ICommandHandler<UpdateShelterCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IDomainEventDispatcher _eventDispatcher;

    public UpdateShelterCommandHandler(IShelterRepository shelterRepository,IDomainEventDispatcher eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
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

        shelter.Update(command.OrganizationName, command.Longitude, command.Latitude, command.PhoneNumber, command.Krs,
            command.Nip);
        
        await _eventDispatcher.DispatchAsync(shelter.Events.ToArray());

        await _shelterRepository.UpdateAsync(shelter);
    }
}