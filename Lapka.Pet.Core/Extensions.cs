using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Lapka.Pet.Core.DomainThings.Kernel;

public static class Extensions
{
    public static IServiceCollection AddDomainEvents(this IServiceCollection services)
    {
        services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
        
        services.Scan((Action<ITypeSourceSelector>)(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses((Action<IImplementationTypeFilter>)(c =>
                    c.AssignableTo(typeof(IDomainEventHandler<>))))
                .AsImplementedInterfaces().WithTransientLifetime()));
        
        return services;
    }
}