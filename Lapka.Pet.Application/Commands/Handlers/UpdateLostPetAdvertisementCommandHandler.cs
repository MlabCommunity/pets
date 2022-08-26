using Convey.CQRS.Commands;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateLostPetAdvertisementCommandHandler : ICommandHandler<UpdateLostPetAdvertisementCommand>
{
    private readonly ILostPetAdvertisementRepository _lostPetAdvertisementRepository;
    private readonly IPetRepository _petRepository;

    public UpdateLostPetAdvertisementCommandHandler(ILostPetAdvertisementRepository lostPetAdvertisementRepository,
        IPetRepository petRepository)
    {
        _lostPetAdvertisementRepository = lostPetAdvertisementRepository;
        _petRepository = petRepository;
    }

    public async Task HandleAsync(UpdateLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisement = await _lostPetAdvertisementRepository.FindByPetIdAsync(command.PetId);

        if (advertisement is null || advertisement.UserId != command.PrincipalId)
        {
            throw new AdvertisementNotFoundException();
        }

        advertisement.Update(command.Description, command.FirstName, command.PhoneNumber);

        await _lostPetAdvertisementRepository.UpdateAsync(advertisement);
    }
}