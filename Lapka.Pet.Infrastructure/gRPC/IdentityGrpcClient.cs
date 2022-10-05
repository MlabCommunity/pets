using Grpc.Net.Client;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Services;

namespace Lapka.Pet.Infrastructure.gRPC;

internal sealed class IdentityGrpcClient : IIdentityGrpcClient
{
    private readonly IdentityPetService.IdentityPetServiceClient _client;
    private readonly GrpcChannel _channel;


    public IdentityGrpcClient(GrpcSettings grpcSettings)
    {
        _channel = GrpcChannel.ForAddress(grpcSettings.IdentityServerAddress);
        _client = new IdentityPetService.IdentityPetServiceClient(_channel);
    }

    public async Task<WorkerDto> GiveWorkerRole(string email)
    {
        var result = _client.GiveWorkerRole(new GiveWorkerRoleRequest
        {
            Email = email
        });

        return new WorkerDto
        {
            Email = email,
            FirstName = result.FirstName,
            LastName = result.LastName,
            WorkerId = Guid.Parse(result.UserId)
        };
    }
    
    public async Task RemoveWorkerRole(Guid userId)
    {
        _client.RemoveWorkerRole(new RemoveWorkerRoleRequest()
        {
            UserId = userId.ToString()
        });
    }
}