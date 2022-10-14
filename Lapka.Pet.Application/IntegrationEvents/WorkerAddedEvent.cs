using Convey.CQRS.Events;

namespace Lapka.Pet.Application.IntegrationEvents;

public record WorkerAddedEvent(Guid UserId,Guid ShelterId) : IEvent;
