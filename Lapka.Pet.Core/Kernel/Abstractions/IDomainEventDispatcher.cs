namespace Lapka.Pet.Core.Kernel.Abstractions;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(params IDomainEvent[] events);
}