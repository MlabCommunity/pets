using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Core.Events;

public record RemovedWorkerEvent(Guid UserId, Guid ShelterId) : IDomainEvent;