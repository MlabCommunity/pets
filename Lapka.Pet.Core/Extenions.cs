using Lapka.Pet.Core.Kernel.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Lapka.Pet.Core;

public static class Extenions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}