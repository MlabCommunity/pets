using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Events;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.DomainEvents.Handlers;

internal sealed class ShelterUpdatedEventHandler : IDomainEventHandler<ShelterUpdatedEvent>
{
    private readonly IShelterRepository _shelterRepository;

    public ShelterUpdatedEventHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(ShelterUpdatedEvent @event)
    {
        var shelter = await _shelterRepository.FindByIdAsync(@event.Id);

        if (shelter is null)
        {
            return;
        }

        foreach (var pet in shelter.ShelterPets)
        {
            pet.UpdateShelterDetails(@event.OrganizationName, @event.Longitude, @event.Latitude);
        }

        await _shelterRepository.UpdateAsync(shelter);
    }
}