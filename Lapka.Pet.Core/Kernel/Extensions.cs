using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Pet.Core.DomainThings.Kernel;

public static class Extensions
{
    public static IServiceCollection AddDomainEvents(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
        services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}