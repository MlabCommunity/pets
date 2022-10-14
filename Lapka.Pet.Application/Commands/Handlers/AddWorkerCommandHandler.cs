using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using Convey.MessageBrokers.CQRS;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class AddWorkerCommandHandler : ICommandHandler<AddWorkerCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IIdentityGrpcClient _client;
    private readonly IBusPublisher _busPublisher;

    public AddWorkerCommandHandler(IShelterRepository shelterRepository, IIdentityGrpcClient client, IBusPublisher busPublisher)
    {
        _client = client;
        _busPublisher = busPublisher;
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

        var result = await _client.GiveWorkerRole(command.Email);

        shelter.AddWorker(result.WorkerId, command.Email, result.FirstName, result.LastName);
        await _shelterRepository.UpdateAsync(shelter);

        await _busPublisher.PublishAsync(new WorkerAddedEvent(result.WorkerId,shelter.Id));
    }
}