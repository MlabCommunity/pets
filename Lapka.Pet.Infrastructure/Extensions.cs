using Lapka.Pet.Application.Services;
using Lapka.Pet.Infrastructure.CacheStorage;
using Lapka.Pet.Infrastructure.Database;
using Lapka.Pet.Infrastructure.Exceptions;
using Lapka.Pet.Infrastructure.Services;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Lapka.Pet.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddHostedService<AppInitializer>();
        services.AddScoped<ExceptionMiddleware>();
        services.AddScoped<ICacheStorage, CacheStorage.CacheStorage>();
        services.AddScoped<IUserCacheStorage, UserCacheStorage>();

        services.AddSingleton<IEventProcessor, EventProcessor>();
        services.AddSingleton<IEventMapper, EventMapper>();

        return services;
    }

    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }

    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
        services.AddFluentValidationRulesToSwagger();
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app)
    {
        return
            app.UseSwagger(c =>
                {
                    c.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
                    {
                        if (!httpRequest.Headers.ContainsKey("X-Forwarded-Host"))
                            return;

                        var basePath = "pet";
                        var serverUrl = $"{httpRequest.Scheme}://{httpRequest.Headers["X-Forwarded-Host"]}/{basePath}";
                        swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
                    });
                })
                .UseSwaggerUI();
    }
}