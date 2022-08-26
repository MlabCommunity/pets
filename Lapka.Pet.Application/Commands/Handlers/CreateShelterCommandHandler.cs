using Convey.CQRS.Commands;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterCommandHandler : ICommandHandler<CreateShelterCommand>
{
    private readonly IShelterRepository _shelterRepository;

    public CreateShelterCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(CreateShelterCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = Shelter.Create(command.UserId, new Localization(command.City, command.Street), command.ZipCode,
            command.OrganizationName,
            command.Krs, command.Nip);

        await _shelterRepository.AddAsync(shelter);
    }
}