using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Pet.Application.IntegrationEvents;

[Message("pet")]
public record WorkerRemovedEvent(Guid UserId, Guid ShelterId) : IEvent;