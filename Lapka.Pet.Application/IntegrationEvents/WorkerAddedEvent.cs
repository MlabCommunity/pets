using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Pet.Application.IntegrationEvents;

[Message("pet")]
public record WorkerAddedEvent(Guid UserId, Guid ShelterId) : IEvent;