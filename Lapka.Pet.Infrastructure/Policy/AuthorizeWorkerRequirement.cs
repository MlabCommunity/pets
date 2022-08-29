using Lapka.Pet.Core.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Lapka.Pet.Infrastructure.Attributes;

internal class IsWorkerRequirement : IAuthorizationRequirement
{
}