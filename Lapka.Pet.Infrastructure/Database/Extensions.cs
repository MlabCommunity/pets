using Convey;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Database.Repositories;
using Lapka.Pet.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Pet.Infrastructure.Database;

public static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPetRepository, PetRepository>();
        services.AddScoped<IShelterRepository, ShelterRepository>();
        services.AddScoped<ILostPetAdvertisementRepository, LostPetAdvertisementRepository>();
        services.AddScoped<IShelterAdvertisementRepository, ShelterAdvertisementRepository>();

        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<AppDbContext>(ctx =>
            ctx.UseNpgsql(options.ConnectionString));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped<IAppDbContext, AppDbContext>();

        return services;
    }
}