using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteShelterCommandHandler : ICommandHandler<DeleteShelterCommand>
{
    private readonly IShelterRepository _shelterRepository;

    public DeleteShelterCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(DeleteShelterCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByUserIdAsync(command.UserId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        await _shelterRepository.DeleteAsync(shelter);
    }
}