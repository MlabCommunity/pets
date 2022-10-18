using Convey.CQRS.Events;
using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Application.Services;

public interface IEventMapper
{
    IEvent Map(IDomainEvent @event);
    IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
}