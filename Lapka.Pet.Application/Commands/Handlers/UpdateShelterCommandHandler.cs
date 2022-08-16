using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateShelterCommandHandler : ICommandHandler<UpdateShelterCommand>
{
    private readonly IShelterRepository _shelterRepository;

    public UpdateShelterCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(UpdateShelterCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByUserIdAsync(command.UserId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.Update(command.OrganizationName, command.Street, command.City, command.ZipCode, command.Krs,
            command.Nip);

        await _shelterRepository.UpdateAsync(shelter);
    }
}