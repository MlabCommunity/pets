using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Services;

public interface IIdentityGrpcClient
{
    Task<WorkerDto> GiveWorkerRole(string email);
    Task RemoveWorkerRole(Guid userId);
}