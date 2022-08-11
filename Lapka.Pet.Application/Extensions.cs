using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
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
            .AddInMemoryQueryDispatcher();

        
        return builder.Build();
    }
    

}