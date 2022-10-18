namespace Lapka.Pet.Core.Kernel.Abstractions;

public interface IDomainEventHandler<in T> where T : class, IDomainEvent
{
    Task HandleAsync(T @event);
}