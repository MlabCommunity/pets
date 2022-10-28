using Convey.CQRS.Events;
using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Application.Services;

public interface IEventProcessor
{
    Task ProcessAsync(IEnumerable<IDomainEvent> events);
    Task ProcessAsync(IEnumerable<IEvent> events);
}