using System.Text.Json;
using AutoMapper.Execution;
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
    public async Task<IActionResult> DeletePet([FromRoute] Guid petId)
    {
        var command = new DeleteCardCommand(petId, GetPrincipalId());

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize]
    [HttpGet("{petId:guid}")]
    [SwaggerOperation(description: "Gets card")]
    [SwaggerResponse(200, "Card found")]
    [SwaggerResponse(404, "Card not found")]
    public async Task<ActionResult<PetDto>> GetPet(Guid petId)
    {
        var query = new GetPetQuery(petId);
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }
    
    [Authorize]
    [HttpGet]
    [SwaggerOperation(description: "Gets all cards")]
    [SwaggerResponse(200)]
    public async Task<ActionResult<PetDto>> GetPets()
    {
        var query = new GetAllPetsQuery(GetPrincipalId());
        var result = await _queryDispatcher.QueryAsync(query);
        List<object> x = result.Cast<object>().ToList();
        return Ok(x);
    }

    [Authorize]
    [HttpGet("visits/{petId:guid}")]
    [SwaggerOperation(description: "Gets visits by petId")]
    [SwaggerResponse(200, "Returns list of visits or empty list")]
    public async Task<ActionResult<List<VisitDto>>> GetVisits([FromRoute] Guid petId)
    {
        var query = new GetAllVisitsQuery(petId, GetPrincipalId());

        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("visits/{petId:guid}/{visitId:guid}")]
    [SwaggerOperation(description: "Gets visit by petId")]
    [SwaggerResponse(200, "Returns visit")]
    [SwaggerResponse(404, "If visit or pet not found")]
    public async Task<ActionResult<VisitDto>> GetVisit([FromRoute] Guid visitId,[FromRoute] Guid petId)
    {
        var query = new GetVisitQuery(petId,visitId, GetPrincipalId());

        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }
    
    [Authorize]
    [HttpDelete("visits/{petId:guid}/{visitId:guid}")]
    [SwaggerOperation(description: "Deletes visit by petId and visitId")]
    [SwaggerResponse(204, "Visit deleted")]
    public async Task<ActionResult<VisitDto>> DeleteVisit([FromRoute] Guid visitId,[FromRoute] Guid petId)
    {
        var command = new DeleteVisitCommand(petId, visitId, GetPrincipalId());

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    
    
    [Authorize]
    [HttpPost("visits/{petId:guid}")]
    [SwaggerOperation(description: "Adds visit")]
    [SwaggerResponse(204, "Visit added")]
    [SwaggerResponse(404, "Pet not found")]
    public async Task<IActionResult> CreateVisit([FromBody] CreateVisitRequest request,[FromRoute] Guid petId)
    {
        var command = new CreateVisitCommand(petId,GetPrincipalId(),request.HasTookPlace,request.DateOfVisit,request.Description,request.VisitTypes,request.WeightOnVisit);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    
    [Authorize]
    [HttpPut("visits/{petId:guid}/{visitId:guid}")]
    [SwaggerOperation(description: "Adds visit")]
    [SwaggerResponse(204, "Visit added")]
    [SwaggerResponse(404, "Pet not found")]
    public async Task<IActionResult> UpdateVisit([FromBody] UpdateVisitRequest request,[FromRoute] Guid petId,[FromRoute] Guid visitId)
    {
        var command = new UpdateVisitCommand(petId,visitId,GetPrincipalId(),request.HasTookPlace,request.DateOfVisit,request.Description,request.VisitTypes,request.WeightOnVisit);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
}