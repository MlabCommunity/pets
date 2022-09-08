using Convey.CQRS.Events;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.IntegrationEvents.Handlers;

internal sealed class UserDeletedEventHandler : IEventHandler<UserDeletedEvent>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IPetRepository _petRepository;

    public UserDeletedEventHandler(IShelterRepository shelterRepository,IPetRepository petRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(UserDeletedEvent @event, CancellationToken cancellationToken = new CancellationToken())
    {

        var shelter = await _shelterRepository.FindByIdAsync(@event.UserId);
        
        if (shelter is not null)
        {
            await _shelterRepository.DeleteAsync(shelter);
        }

        await _petRepository.RemoveByOwnerIdAsync(@event.UserId);

    }
}