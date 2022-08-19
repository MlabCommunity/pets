using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteShelterAdvertisementCommandHandler : ICommandHandler<DeleteShelterAdvertisementCommand>
{
    
    private readonly IShelterRepository _shelterRepository;
    
    public DeleteShelterAdvertisementCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }
    
    public async Task HandleAsync(DeleteShelterAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdOrWorkerIdAsync(command.PetId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }
        
        shelter.RemoveAdvertisement(command.PetId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}