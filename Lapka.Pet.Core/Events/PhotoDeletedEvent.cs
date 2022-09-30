using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.Events;

public record PhotoDeletedEvent(string Link) : IDomainEvent;