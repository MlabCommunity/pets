using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lapka.Pet.Api.Controllers;

public class CardController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CardController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [Authorize]
    [HttpPost("dog")]
    public async Task<IActionResult> CreateDog([FromBody] CreateDogRequest request)
    {
        var ownerId = GetPrincipalId();
        var role = GetPrincipalRole();
        var command = new CreateDogCommand(ownerId, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.DogColor, request.DogBreed);

        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }

    [Authorize]
    [HttpPost("cat")]
    public async Task<IActionResult> CreatePet([FromBody] CreateCatRequest request)
    {
        var ownerId = GetPrincipalId();

        var command = new CreateCatCommand(ownerId, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize]
    [HttpPost("other")]
    public async Task<IActionResult> CreateOtherPet([FromBody] CreateOtherPetRequest request)
    {
        var ownerId = GetPrincipalId();

        var command = new CreateOtherPetCommand(ownerId, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdatePet([FromBody] UpdatePetRequest request)
    {
        var command = new UpdatePetCommand(request.PetId, request.Name, request.IsSterilized, request.Weight);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    
    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PetDto>> GetPet(Guid id)
    {
        var query = new GetPetQuery(id);
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }
}