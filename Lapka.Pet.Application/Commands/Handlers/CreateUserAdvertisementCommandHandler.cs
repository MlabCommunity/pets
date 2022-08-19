using Convey.CQRS.Commands;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateUserAdvertisementCommandHandler : ICommandHandler<CreateUserAdvertisementCommand>
{
    private readonly IUserAdvertisementRepository _userAdvertisementRepository;

    public CreateUserAdvertisementCommandHandler(IUserAdvertisementRepository userAdvertisementRepository)
    {
        _userAdvertisementRepository = userAdvertisementRepository;
    }
    
    public Task HandleAsync(CreateUserAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisement = new UserAdvertisement(command.Description, command.IsVisible, command.DateOfDisappearance,
            command.StreetOfDisappearance, command.CityOfDisappearance, command.PetId);
    }
}