using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Core.Events;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteShelterCommandHandler : ICommandHandler<DeleteShelterCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IBusPublisher _busPublisher;
    private readonly IPetRepository _petRepository;

    public DeleteShelterCommandHandler(IShelterRepository shelterRepository, IBusPublisher busPublisher,
        IPetRepository petRepository)
    {
        _shelterRepository = shelterRepository;
        _busPublisher = busPublisher;
        _petRepository = petRepository;
    }

    public async Task HandleAsync(DeleteShelterCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdAsync(command.UserId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var pets = await _petRepository.FindByOwnerId(shelter.Id.Value);

        foreach (var pet in pets)
        {
            foreach (var photo in pet.Photos)
            {
                await _busPublisher.PublishAsync(new FileDeletedEvent(photo.Link));
            }
        }

        await _shelterRepository.DeleteAsync(shelter);
    }
}