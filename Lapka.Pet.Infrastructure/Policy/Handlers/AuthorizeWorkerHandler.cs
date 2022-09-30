using System.Security.Claims;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

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
        var stringId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(stringId))
        {
            throw new ProjectUnauthorized();
        }

        var principalId = Guid.Parse(stringId);

        var query = new GetShelterIdByOwnerIdOrWorkerIdQuery(principalId);
        var shelterId = await _queryDispatcher.QueryAsync(query);

        if (shelterId == Guid.Empty)
        {
            throw new DomainForbidden();
        }

        _cacheStorage.SetShelterId(principalId, shelterId);

        context.Succeed(requirement);
    }
}