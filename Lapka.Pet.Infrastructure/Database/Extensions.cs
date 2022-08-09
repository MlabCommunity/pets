using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Pet.Infrastructure.Database;

public static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        //Add repositories here
        
        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<Context>(ctx =>
            ctx.UseNpgsql(options.ConnectionString));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //Add contexts here
        
        return services;
    }
}