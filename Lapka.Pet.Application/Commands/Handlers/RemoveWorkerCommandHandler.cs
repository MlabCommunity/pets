using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class RemoveWorkerCommandHandler : ICommandHandler<RemoveWorkerCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IIdentityGrpcClient _client;
    private readonly IBusPublisher _busPublisher;
    

    public RemoveWorkerCommandHandler(IShelterRepository shelterRepository, IIdentityGrpcClient client, IBusPublisher busPublisher)
    {
        _shelterRepository = shelterRepository;
        _client = client;
        _busPublisher = busPublisher;
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

        await _busPublisher.PublishAsync(new WorkerRemovedEvent(command.WorkerId,command.ShelterId));
    }
}