using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterAdvertisementCommandHandler : ICommandHandler<CreateShelterAdvertisementCommand>
{
    private readonly IShelterRepository _shelterRepository;

    public CreateShelterAdvertisementCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(CreateShelterAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdOrWorkerIdAsync(command.PrincipalId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.AddAdvertisement(new ShelterAdvertisement(command.Description,
            command.IsVisible, command.PetId));
        
        await _shelterRepository.UpdateAsync(shelter);
    }
}