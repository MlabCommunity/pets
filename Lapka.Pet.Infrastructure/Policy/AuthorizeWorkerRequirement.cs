using Microsoft.AspNetCore.Authorization;

namespace Lapka.Pet.Infrastructure.Policy;

internal class IsWorkerRequirement : IAuthorizationRequirement
{
}