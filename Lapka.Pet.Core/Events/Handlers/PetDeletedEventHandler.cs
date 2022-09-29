using Convey.CQRS.Events;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Events;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.DomainEvents.Handlers;

internal sealed class PetDeletedEventHandler : IEventHandler<PetDeletedEvent>
{
    private readonly IPetRepository _petRepository;

    public PetDeletedEventHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }


    public async Task HandleAsync(PetDeletedEvent @event, CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(@event.PetId);

        if (pet is not null)
        {
            await _petRepository.RemoveAsync(pet);
        }
    }
}