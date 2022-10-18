using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Kernel.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Pet.Infrastructure.Services;

internal sealed class EventProcessor : IEventProcessor
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IEventMapper _eventMapper;
    private readonly IBusPublisher _busPublisher;

    public EventProcessor(IServiceScopeFactory serviceScopeFactory, IEventMapper eventMapper,
        IBusPublisher busPublisher)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _eventMapper = eventMapper;
        _busPublisher = busPublisher;
    }

    public async Task ProcessAsync(IEnumerable<IDomainEvent> events)
    {
        if (events is null)
        {
            return;
        }

        var integrationEvents = await HandleDomainEvents(events);
        if (!integrationEvents.Any())
        {
            return;
        }

        foreach (var @event in integrationEvents)
        {
            await _busPublisher.PublishAsync(@event);
        }
    }

    private async Task<List<IEvent>> HandleDomainEvents(IEnumerable<IDomainEvent> events)
    {
        var integrationEvents = new List<IEvent>();
        using var scope = _serviceScopeFactory.CreateScope();
        foreach (var @event in events)
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(@event.GetType());
            var handlers = scope.ServiceProvider.GetServices(handlerType);

            var tasks = handlers.Select(x => (Task)handlerType
                .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))
                ?.Invoke(x, new[] { @event }));

            await Task.WhenAll(tasks);

            var integrationEvent = _eventMapper.Map(@event);
            if (integrationEvent is null)
            {
                continue;
            }

            integrationEvents.Add(integrationEvent);
        }

        return integrationEvents;
    }
}