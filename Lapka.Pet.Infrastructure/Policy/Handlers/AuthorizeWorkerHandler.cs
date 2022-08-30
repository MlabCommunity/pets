using System.Security.Claims;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Infrastructure.Database.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Lapka.Pet.Infrastructure.Policy.Handlers;

internal class AuthorizeWorkerHandler : AuthorizationHandler<IsWorkerRequirement>
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IUserCacheStorage _cacheStorage;

    public AuthorizeWorkerHandler(IQueryDispatcher queryDispatcher, IUserCacheStorage cacheStorage)
    {
        _queryDispatcher = queryDispatcher;
        _cacheStorage = cacheStorage;
    }


    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        IsWorkerRequirement requirement)
    {
        var principalId = Guid.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));

        var query = new GetShelterIdByOwnerIdOrWorkerIdQuery(principalId);
        var shelterId = await _queryDispatcher.QueryAsync(query);

        if (shelterId == Guid.Empty)
        {
            context.Fail();
        }

        _cacheStorage.SetShelterId(principalId, shelterId);

        context.Succeed(requirement);
    }
}