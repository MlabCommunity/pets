namespace Lapka.Pet.Core.DomainThings;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(params IDomainEvent[] events);
}