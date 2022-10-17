using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteLostPetAdvertisementCommandHandler : ICommandHandler<DeleteLostPetAdvertisementCommand>
{
    private readonly ILostPetRepository _lostPetRepository;
    private readonly IBusPublisher _busPublisher;
    
    public DeleteLostPetAdvertisementCommandHandler(ILostPetRepository lostPetRepository, IBusPublisher busPublisher)
    {
        _lostPetRepository = lostPetRepository;
        _busPublisher = busPublisher;
    }

    public async Task HandleAsync(DeleteLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var lostPet = await _lostPetRepository.FindByPetIdAsync(command.PetId);

        if (lostPet is null || lostPet.OwnerId != command.PrincipalId)
        {
            throw new AdvertisementNotFoundException();
        }
        
        var temp = lostPet.Photos;
        
        await _lostPetRepository.DeleteAsync(lostPet);
        
        foreach (var photo in temp)
        {
            await _busPublisher.PublishAsync(new FileDeletedEvent(photo.Link));
        }
    }
}