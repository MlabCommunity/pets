using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateShelterAdvertisementCommandHandler : ICommandHandler<UpdateShelterAdvertisementCommand>
{
    private readonly IShelterRepository _shelterRepository;
    
    public UpdateShelterAdvertisementCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }
    
    public async Task HandleAsync(UpdateShelterAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdOrWorkerIdAsync(command.PrincipalId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }
        
        shelter.UpdateAdvertisement(command.AdvertisementId,command.Description);

        await _shelterRepository.UpdateAsync(shelter);
    }
}