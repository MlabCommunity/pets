using System.Runtime.CompilerServices;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    [HttpGet("shelters/{longitude:double}/{latitude:double}")]
    [SwaggerOperation(description: "Gets all shelter advertisements")]
    [SwaggerResponse(200, "advertisements found or returns empty list",
        typeof(Application.Dto.PagedResult<ShelterPetAdvertisementDto>))]
    public async Task<ActionResult<Application.Dto.PagedResult<ShelterPetAdvertisementDto>>> GetAllShelterAdvertisement(
        [FromRoute] double longitude, [FromRoute] double latitude,
        [FromQuery] PetType? type, [FromQuery] Gender? gender, [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new GetAllShelterAdvertisementQuery(type, gender, longitude,latitude,pageNumber, pageSize);

        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }

    [HttpGet("shelters/{petId:guid}/{longitude:double}/{latitude:double}")]
    [SwaggerOperation(description: "Gets shelter's advertisement details")]
    [SwaggerResponse(200, "advertisements found", typeof(List<ShelterPetAdvertisementDetailsDto>))]
    [SwaggerResponse(404, "advertisements not found")]
    public async Task<ActionResult<ShelterPetAdvertisementDetailsDto>> GetShelterAdvertisementDetails(
        [FromRoute] Guid petId, [FromRoute] double longitude, [FromRoute] double latitude)
    {
        var query = new GetShelterAdvertisementDetailsQuery(petId, longitude, latitude);

        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPost("dog")]
    [SwaggerOperation(description: "Creates lost pet's card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> CreateLostDog([FromBody] CreateLostDogAdvertisementRequest request)
    {
        var command = new CreateLostDogCommand(GetPrincipalId(), request.ProfilePhoto, request.Name, request.Gender,
            request.DateOfBirth,
            request.IsSterilized,
            request.Weight, request.DogColor, request.DogBreed, request.Photos, request.Description, request.FirstName,
            request.PhoneNumber,
            request.IsVisible, request.DateOfDisappearance, request.Longitude, request.Latitude);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPost("cat")]
    [SwaggerOperation(description: "Creates lost pet's card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> CreateLostCat([FromBody] CreateLostCatAdvertisementRequest request)
    {
        var command = new CreateLostCatCommand(GetPrincipalId(), request.ProfilePhotoId, request.Name, request.Gender,
            request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed, request.Photos,
            request.Description,
            request.FirstName, request.PhoneNumber, request.IsVisible, request.DateOfDisappearance, request.Longitude,
            request.Latitude);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPost("other")]
    [SwaggerOperation(description: "Creates lost pet's card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> CreateLostOtherPet([FromBody] CreateLostOtherPetAdvertisementRequest request)
    {
        var command = new CreateLostOtherPetCommand(GetPrincipalId(), request.ProfilePhoto, request.Name,
            request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.Photos, request.Description,
            request.FirstName, request.PhoneNumber, request.IsVisible, request.DateOfDisappearance, request.Longitude,
            request.Latitude);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation(description: "get all lost pet's card")]
    [SwaggerResponse(200, "Cards found or returns empty list", typeof(List<LostPetAdvertisementDto>))]
    public async Task<ActionResult<Application.Dto.PagedResult<LostPetAdvertisementDto>>> GetAllLostPetAdvertisement(
        [FromQuery] PetType? type, [FromQuery] Gender? gender, [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new GetAllLostPetAdvertisementQuery(type, gender, pageNumber, pageSize);
        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }

    [HttpGet("{petId:guid}/{longitude:double}/{latitude:double}")]
    [SwaggerOperation(description: "get lost pet's card details")]
    [SwaggerResponse(200, "Card found", typeof(LostPetAdvertisementDetailsDto))]
    [SwaggerResponse(404, "Card not found")]
    public async Task<ActionResult<LostPetAdvertisementDetailsDto>> GetLostPetAdvertisementDetails(
        [FromRoute] Guid petId, [FromRoute] double longitude, [FromRoute] double latitude)
    {
        var query = new GetLostPetAdvertisementDetailsQuery(petId,longitude,latitude);
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPut("{petId:guid}")]
    [SwaggerOperation(description: "update lost pet's card")]
    [SwaggerResponse(200, "Cards updated")]
    [SwaggerResponse(404, "Cards not found")]
    public async Task<IActionResult> UpdateLostPetAdvertisement([FromRoute] Guid petId,
        [FromBody] UpdateLostPetAdvertisementRequest request)
    {
        var advertisementCommand = new UpdateLostPetAdvertisementCommand(petId, GetPrincipalId(), request.Description,
            request.FirstName, request.PhoneNumber, request.Name, request.IsSterilized, request.Weight);
        var petCommand =
            new UpdatePetCommand(petId, GetPrincipalId(), request.Name, request.IsSterilized, request.Weight);
        await _commandDispatcher.SendAsync(advertisementCommand);
        await _commandDispatcher.SendAsync(petCommand);

        return NoContent();
    }

    [HttpDelete("{petId:guid}")]
    [SwaggerOperation(description: "delete lost pet's card")]
    [SwaggerResponse(200, "Cards deleted")]
    [SwaggerResponse(404, "Cards not found")]
    public async Task<IActionResult> DeleteLostPetAdvertisement([FromRoute] Guid petId)
    {
        var command = new DeleteLostPetAdvertisementCommand(petId, GetPrincipalId());
        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }
}