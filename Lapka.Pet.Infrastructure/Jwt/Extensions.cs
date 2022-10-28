using Convey;
using Lapka.Pet.Infrastructure.Policy;
using Lapka.Pet.Infrastructure.Policy.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Pet.Infrastructure.Jwt;

public static class Extensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOption = configuration.GetOptions<JwtSettings>("JWT");
        services.AddSingleton(jwtOption);
        services.AddScoped<IAuthorizationHandler, AuthorizeWorkerHandler>();
        services.AddAuthorization(options =>
            options.AddPolicy("IsWorker", policy => policy.Requirements
                .Add(new IsWorkerRequirement())));

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