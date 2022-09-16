using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateLostPetAdvertisementCommandHandler : ICommandHandler<UpdateLostPetAdvertisementCommand>
{
    private readonly ILostPetRepository _lostPetRepository;
    private readonly IPetRepository _petRepository;

    public UpdateLostPetAdvertisementCommandHandler(ILostPetRepository lostPetRepository,
        IPetRepository petRepository)
    {
        _lostPetRepository = lostPetRepository;
        _petRepository = petRepository;
    }

    public async Task HandleAsync(UpdateLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var LostPet = await _lostPetRepository.FindByPetIdAsync(command.PetId);

        if (LostPet is null || LostPet.OwnerId != command.PrincipalId)
        {
            throw new AdvertisementNotFoundException();
        }

        LostPet.Update(command.Description, command.FirstName, command.PhoneNumber,command.PetName,command.IsSterilized,command.Weight);

        await _lostPetRepository.UpdateAsync(LostPet);
    }
}