namespace Lapka.Pet.Application.Services;

public interface IIdentityGrpcClient 
{
    Task GiveWorkerRole(Guid userId);
    Task RemoveWorkerRole(Guid userId);
}