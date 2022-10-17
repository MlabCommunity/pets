using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Application.IntegrationEvents;

public record AddedWorkerEvent(Guid UserId,Guid ShelterId) : IDomainEvent;
