using Convey.CQRS.Events;

namespace Lapka.Pet.Application.IntegrationEvents;

public record WorkerRemovedEvent(Guid UserId,Guid ShelterId) : IEvent;
