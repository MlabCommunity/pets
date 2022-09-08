using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class AddWorkerCommandHandler : ICommandHandler<AddWorkerCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IIdentityGrpcClient _client;

    public AddWorkerCommandHandler(IShelterRepository shelterRepository,IIdentityGrpcClient client)
    {
        _client = client;
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(AddWorkerCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdAsync(command.ShelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.AddWorker(command.WorkerId);

        await _client.GiveWorkerRole(command.WorkerId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}