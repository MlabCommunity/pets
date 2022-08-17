using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class RemoveWorkerCommandHandler : ICommandHandler<RemoveWorkerCommand>
{
    private readonly IShelterRepository _shelterRepository;

    public RemoveWorkerCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(RemoveWorkerCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByUserIdAsync(command.UserId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.RemoveWorker(command.WorkerId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}