using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Pet.Application.IntegrationEvents;

[Message("identity")]
public record UserDeletedEvent(Guid UserId, string Role) : IEvent;