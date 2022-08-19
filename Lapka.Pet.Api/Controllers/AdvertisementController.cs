using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Infrastructure.Database.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lapka.Pet.Api.Controllers;

public class AdvertisementController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public AdvertisementController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }


    [Authorize(Roles = "Shelter,Worker,User")]
    [HttpGet("shelter")]
    public async Task<ActionResult<List<ShelterAdvertisementDto>>> GetAllShelterAdvertisement()
    {
        var query = new GetAllShelterAdvertisementQuery();

        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }


    [Authorize(Roles = "Worker,User")]
    public async Task<IActionResult> CreateUserAdvertisement([FromBody] CreateUserAdvertisementRequest request)
    {
        var command = new CreateUserAdvertisementCommand(GetPrincipalId(), request.Description, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
}