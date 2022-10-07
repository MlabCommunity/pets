namespace Lapka.Pet.Core.Kernel.Abstractions;

public interface IDomainEventHandler<in TEvent> where TEvent : class, IDomainEvent
{
    Task HandleAsync(TEvent @event);
}