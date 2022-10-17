using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Application.Services;

public interface IEventProcessor
{
    Task ProcessAsync(IEnumerable<IDomainEvent> events);
}