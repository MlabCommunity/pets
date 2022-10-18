using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Pet.Application.IntegrationEvents;

[Message("files")]
public record FileDeletedEvent(string FileUrl) : IEvent;