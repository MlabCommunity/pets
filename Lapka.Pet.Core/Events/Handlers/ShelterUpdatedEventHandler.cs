using Lapka.Pet.Core.Kernel.Abstractions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Core.Events.Handlers;

internal sealed class ShelterUpdatedEventHandler : IDomainEventHandler<UpdatedShelterEvent>
{
    private readonly IShelterRepository _shelterRepository;

    public ShelterUpdatedEventHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(UpdatedShelterEvent @event)
    {
        var shelter = await _shelterRepository.FindByIdAsync(@event.Id);

        if (shelter is null)
        {
            return;
        }

        foreach (var pet in shelter.ShelterPets)
        {
            pet.UpdateShelterDetails(@event.OrganizationName, @event.Longitude, @event.Latitude, @event.City,
                @event.Street, @event.ZipCode);
        }

        await _shelterRepository.UpdateAsync(shelter);
    }
}