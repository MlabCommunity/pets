using Convey.CQRS.Commands;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteLostPetAdvertisementCommandHandler : ICommandHandler<DeleteLostPetAdvertisementCommand>
{
    private readonly ILostPetAdvertisementRepository _lostPetAdvertisementRepository;
    private readonly IPetRepository _petRepository;

    public DeleteLostPetAdvertisementCommandHandler(ILostPetAdvertisementRepository lostPetAdvertisementRepository,
        IPetRepository petRepository)
    {
        _lostPetAdvertisementRepository = lostPetAdvertisementRepository;
        _petRepository = petRepository;
    }

    public async Task HandleAsync(DeleteLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisement = await _lostPetAdvertisementRepository.FindByPetIdAsync(command.PetId);

        if (advertisement is null || advertisement.UserId != command.PrincipalId)
        {
            throw new AdvertisementNotFoundException();
        }

        await _lostPetAdvertisementRepository.DeleteAsync(advertisement); //TODO chyba nie da sie tego ogrnac eventami
        await _petRepository.RemoveByIdAsync(advertisement.PetId.Value);
    }
}