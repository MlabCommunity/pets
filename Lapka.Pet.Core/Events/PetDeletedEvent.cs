

using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.Events;

public record PetDeletedEvent(Guid PetId) : IDomainEvent;
