using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Infrastructure.Database.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lapka.Pet.Api.Controllers;

public class ShelterController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ShelterController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateShelter([FromBody] UpdateShelterRequest request)
    {
        var command = new UpdateShelterCommand(GetPrincipalId(), request.Street, request.Street, request.ZipCode,
            request.OrganizationName, request.Krs, request.Nip);

        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<ShelterDto>> GetShelter()
    {
        var query = new GetShelterQuery(GetPrincipalId());

        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }
}