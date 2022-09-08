using System.Reflection;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Pet.Application;

public static class Extensions
{
    public static IServiceProvider AddApplication(this IServiceCollection services)
    {
        
        var builder = services.AddConvey()
            .AddCommandHandlers()
            .AddInMemoryCommandDispatcher()
            .AddQueryHandlers()
            .AddInMemoryQueryDispatcher()
            .AddEventHandlers()
            .AddServiceBusEventDispatcher()
            .AddRabbitMq();

        return builder.Build();
    }
}