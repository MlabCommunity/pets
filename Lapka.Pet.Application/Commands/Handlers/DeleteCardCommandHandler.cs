using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteCardCommandHandler : ICommandHandler<DeleteCardCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IBusPublisher _busPublisher;

    public DeleteCardCommandHandler(IPetRepository petRepository, IBusPublisher busPublisher)
    {
        _busPublisher = busPublisher;
        _petRepository = petRepository;
    }

    public async Task HandleAsync(DeleteCardCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(command.PetId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }

        if (pet.OwnerId != command.PrincipalId)
        {
            throw new ProjectForbidden();
        }

        var temp = pet.Photos;

        await _petRepository.RemoveAsync(pet);
        
        foreach (var photo in temp)
        {
            await _busPublisher.PublishAsync(new FileDeletedEvent(photo.Link));
        }
    }
}