using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteLostPetAdvertisementCommandHandler : ICommandHandler<DeleteLostPetAdvertisementCommand>
{
    private readonly ILostPetRepository _lostPetRepository;

    public DeleteLostPetAdvertisementCommandHandler(ILostPetRepository lostPetRepository)
    {
        _lostPetRepository = lostPetRepository;
    }

    public async Task HandleAsync(DeleteLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var lostPet = await _lostPetRepository.FindByPetIdAsync(command.PetId);

        if (lostPet is null || lostPet.OwnerId != command.PrincipalId)
        {
            throw new AdvertisementNotFoundException();
        }

        await _lostPetRepository.DeleteAsync(lostPet);
    }
}