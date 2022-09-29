

using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.Events;

[Message("identity")]
public record PetDeletedEvent(Guid PetId) : IEvent;
