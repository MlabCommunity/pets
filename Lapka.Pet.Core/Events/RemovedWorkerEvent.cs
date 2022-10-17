using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Application.IntegrationEvents;

public record RemovedWorkerEvent(Guid UserId,Guid ShelterId) : IDomainEvent;
