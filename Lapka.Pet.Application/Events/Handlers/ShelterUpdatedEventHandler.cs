using Confab.Shared.Abstractions.Kernel;
using Lapka.Pet.Core.Events;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Events.Handlers;

internal sealed class ShelterUpdatedEventHandler : IDomainEventHandler<ShelterUpdatedEvent>
{
    private readonly IShelterAdvertisementRepository _advertisementRepository;

    public ShelterUpdatedEventHandler(IShelterAdvertisementRepository advertisementRepository)
    {
        _advertisementRepository = advertisementRepository;
    }

    public async Task HandleAsync(ShelterUpdatedEvent @event)
    {
        var advertisement = await _advertisementRepository.FindByShelterIdAsync(@event.Id);

        if (advertisement is null)
        {
            throw new Exception(); //TODO internal? ill ask Adam :)
        }

        advertisement.UpdateShelterDetails(@event.OrganizationName, new Localization(@event.City, @event.Street));

        await _advertisementRepository.UpdateAsync(advertisement);
    }
}