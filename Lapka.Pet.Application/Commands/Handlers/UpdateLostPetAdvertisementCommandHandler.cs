using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateLostPetAdvertisementCommandHandler : ICommandHandler<UpdateLostPetAdvertisementCommand>
{
    private readonly ILostPetRepository _lostPetRepository;
    private readonly IEventProcessor _eventProcessor;

    public UpdateLostPetAdvertisementCommandHandler(ILostPetRepository lostPetRepository, IEventProcessor eventProcessor)
    {
        _lostPetRepository = lostPetRepository;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(UpdateLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var lostPet = await _lostPetRepository.FindByPetIdAsync(command.PetId);

        if (lostPet is null || lostPet.OwnerId != command.PrincipalId)
        {
            throw new AdvertisementNotFoundException();
        }

        lostPet.Update(command.Description, command.FirstName, command.PhoneNumber, command.PetName,
            command.IsSterilized, command.Weight,command.Photos);

        await _lostPetRepository.UpdateAsync(lostPet);

        await _eventProcessor.ProcessAsync(lostPet.Events);
    }
}