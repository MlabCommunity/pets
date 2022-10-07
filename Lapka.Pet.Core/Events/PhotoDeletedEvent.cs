using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Core.Events;

public record PhotoDeletedEvent(string Link) : IDomainEvent;