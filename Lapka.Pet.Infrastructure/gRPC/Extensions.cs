using Convey;
using Lapka.Pet.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Pet.Infrastructure.gRPC;

public static class Extensions
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services, IConfiguration configuration)
    {
        var grpcOptions = configuration.GetOptions<GrpcSettings>("gRPC");
        services.AddSingleton(grpcOptions);
        services.AddScoped<IIdentityGrpcClient, IdentityGrpcClient>();
        return services;
    }
}