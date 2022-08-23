using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateLostPetAdvertisementCommandHandler : ICommandHandler<CreateLostPetAdvertisementCommand>
{
    private readonly ILostPetAdvertisementRepository _lostPetAdvertisementRepository;

    public CreateLostPetAdvertisementCommandHandler(ILostPetAdvertisementRepository lostPetAdvertisementRepository)
    {
        _lostPetAdvertisementRepository = lostPetAdvertisementRepository;
    }

    public async Task HandleAsync(CreateLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _lostPetAdvertisementRepository.FindByPetIdAsync(command.PetId);

        if (pet is not null)
        {
            throw new AdvertisementWithThisPetAlreadyExistsException();
        }

        var advertisement = new LostPetAdvertisement(command.Description, command.IsVisible,
            command.DateOfDisappearance,
            command.StreetOfDisappearance, command.CityOfDisappearance, command.PetId,command.PrincipalId);

        await _lostPetAdvertisementRepository.AddAsync(advertisement);
    }
}