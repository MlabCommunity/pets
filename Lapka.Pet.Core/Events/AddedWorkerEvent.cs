using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Core.Events;

public record AddedWorkerEvent(Guid UserId, Guid ShelterId) : IDomainEvent;