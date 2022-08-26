using Lapka.Pet.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Pet.Infrastructure.Jwt;

public static class Extensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOption = configuration.GetOptions<JwtSettings>("JWT");
        services.AddSingleton(jwtOption);
        services.AddAuthorization();

        services
            .AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                opts => { opts.TokenValidationParameters = JwtParamsFactory.CreateParameters(jwtOption); });

        return services;
    }
}