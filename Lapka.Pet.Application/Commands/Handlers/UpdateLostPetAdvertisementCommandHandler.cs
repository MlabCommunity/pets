using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateLostPetAdvertisementCommandHandler : ICommandHandler<UpdateLostPetAdvertisementCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IEventProcessor _eventProcessor;

    public UpdateLostPetAdvertisementCommandHandler(IPetRepository petRepository,
        IEventProcessor eventProcessor)
    {
        _petRepository = petRepository;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(UpdateLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        
        var lostPet = await _petRepository.FindByIdAsync(command.PetId) as LostPet;

        if (command.PrincipalId != lostPet.OwnerId)
        {
            throw new ProjectForbidden();
        }
        
        if (lostPet is null)
        {
            throw new AdvertisementNotFoundException();
        }

        lostPet.Update(command.Description, command.FirstName, command.PhoneNumber, command.PetName,
            command.IsSterilized, command.Weight, command.Photos);

        await _petRepository.UpdateAsync(lostPet);

        await _eventProcessor.ProcessAsync(lostPet.Events);
    }
}