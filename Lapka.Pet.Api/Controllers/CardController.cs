using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Infrastructure.Database.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    [Authorize(Roles = "User,Worker")]
    [HttpPost("dog")]
    [SwaggerOperation(description: "Create card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    [SwaggerResponse(404, "If user not found")]
    public async Task<IActionResult> CreateDog([FromBody] CreateDogRequest request)
    {
        var command = new CreateDogCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.DogColor, request.DogBreed, request.Photos);

        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPost("cat")]
    [SwaggerOperation(description: "Create card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    [SwaggerResponse(404, "If user not found")]
    public async Task<IActionResult> CreateCat([FromBody] CreateCatRequest request)
    {
        var command = new CreateCatCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed, request.Photos);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPost("other")]
    [SwaggerOperation(description: "Creates card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    [SwaggerResponse(404, "If user not found")]
    public async Task<IActionResult> CreateOtherPet([FromBody] CreateOtherPetRequest request)
    {
        var command = new CreateOtherPetCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.Photos);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPut]
    [SwaggerOperation(description: "Updates card")]
    [SwaggerResponse(200, "Card updated")]
    [SwaggerResponse(400, "If data are invalid")]
    [SwaggerResponse(404, "If user not found")]
    public async Task<IActionResult> UpdatePet([FromBody] UpdatePetRequest request)
    {
        var command = new UpdatePetCommand(request.PetId, GetPrincipalId(), request.Name, request.IsSterilized,
            request.Weight);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Roles = "User,Worker")]
    [HttpDelete("{petId:guid}")]
    [SwaggerOperation(description: "Deletes card")]
    [SwaggerResponse(200, "Card deleted")]
    [SwaggerResponse(404, "If user not found")]
    public async Task<IActionResult> DeletePet([FromRoute] Guid petId)
    {
        var command = new DeleteCardCommand(petId, GetPrincipalId());

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize]
    [HttpGet("{id:guid}")]
    [SwaggerOperation(description: "Updates card")]
    [SwaggerResponse(200, "Card found")]
    [SwaggerResponse(404, "If pet not found")]
    public async Task<ActionResult<PetDto>> GetPet(Guid id)
    {
        var query = new GetPetQuery(id);
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }
}