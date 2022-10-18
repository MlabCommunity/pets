using Convey.CQRS.Events;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Events;
using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Infrastructure.Services;

internal sealed class EventMapper : IEventMapper
{
    public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
        => events.Select(Map);

    public IEvent Map(IDomainEvent @event)
        => @event switch
        {
            DeletedFileEvent e => new FileDeletedEvent(e.FileUrl),
            RemovedWorkerEvent e => new WorkerRemovedEvent(e.UserId, e.ShelterId),
            AddedWorkerEvent e => new WorkerAddedEvent(e.UserId, e.ShelterId),
            _ => null
        };
}