using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class RemoveWorkerCommandHandler : ICommandHandler<RemoveWorkerCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IIdentityGrpcClient _client;

    public RemoveWorkerCommandHandler(IShelterRepository shelterRepository, IIdentityGrpcClient client)
    {
        _shelterRepository = shelterRepository;
        _client = client;
    }

    public async Task HandleAsync(RemoveWorkerCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdAsync(command.ShelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.RemoveWorker(command.WorkerId);

        await _client.RemoveWorkerRole(command.WorkerId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}