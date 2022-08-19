using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class PublishShelterAdvertisementCommandHandler : ICommandHandler<PublishShelterAdvertisementCommand>
{
    private readonly IShelterRepository _shelterRepository;
    
    public PublishShelterAdvertisementCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }
    
    public async Task HandleAsync(PublishShelterAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdOrWorkerIdAsync(command.PrincipalId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }
        
        shelter.PublishAdvertisement(command.PetId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}