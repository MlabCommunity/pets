using System.Runtime.CompilerServices;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Infrastructure.Database.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lapka.Pet.Api.Controllers;

public class AdvertisementController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IUserCacheStorage _userCacheStorage;

    public AdvertisementController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher,
        IUserCacheStorage userCacheStorage)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _userCacheStorage = userCacheStorage;
    }
    
    [HttpGet("shelters")]
    [SwaggerOperation(description: "Gets all shelter advertisements")]
    [SwaggerResponse(200, "advertisements found or returns empty list", typeof(Application.Dto.PagedResult<ShelterPetAdvertisementDto>))]
    public async Task<ActionResult<Application.Dto.PagedResult<ShelterPetAdvertisementDto>>> GetAllShelterAdvertisement(
        [FromQuery] PetType? type, [FromQuery] Gender? gender,[FromQuery] int pageNumber =1,[FromQuery] int pageSize=10)
    {
        var query = new GetAllShelterAdvertisementQuery(type, gender,pageNumber,pageSize);

        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }
    
    [HttpGet("shelters/{petId:guid}")]
    [SwaggerOperation(description: "Gets shelter's advertisement details")]
    [SwaggerResponse(200, "advertisements found", typeof(List<ShelterAdvertisementDetailsDto>))]
    public async Task<ActionResult<ShelterAdvertisementDetailsDto>> GetShelterAdvertisementDetails(
        [FromRoute] Guid petId)
    {
        var query = new GetShelterAdvertisementDetailsQuery(petId);

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
        var petCommand = new CreateLostDogCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.DogColor, request.DogBreed, request.Photos);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.FirstName,
            request.PhoneNumber, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance, GetPrincipalId());

        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPost("cat")]
    [SwaggerOperation(description: "Creates lost pet's card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> CreateLostCat([FromBody] CreateLostCatAdvertisementRequest request)
    {
        var petCommand = new CreateLostCatCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed, request.Photos);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.FirstName,
            request.PhoneNumber, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance, GetPrincipalId());
        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPost("other")]
    [SwaggerOperation(description: "Creates lost pet's card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> CreateLostOtherPet([FromBody] CreateLostOtherPetAdvertisementRequest request)
    {
        var petCommand = new CreateLostOtherPetCommand(GetPrincipalId(), request.Name, request.Gender,
            request.DateOfBirth,
            request.IsSterilized, request.Weight, request.Photos);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.FirstName,
            request.PhoneNumber, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance, GetPrincipalId());
        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation(description: "get all lost pet's card")]
    [SwaggerResponse(200, "Cards found or returns empty list", typeof(List<LostPetAdvertisementDto>))]
    public async Task<ActionResult<List<LostPetAdvertisementDto>>> GetAllLostPetAdvertisement([FromQuery] int pageNumber =1,[FromQuery] int pageSize=10)
    {
        var query = new GetAllLostPetAdvertisementQuery(pageNumber,pageSize);
        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }

    [HttpGet("{petId:guid}")]
    [SwaggerOperation(description: "get lost pet's card details")]
    [SwaggerResponse(200, "Card found", typeof(LostPetAdvertisementDetailsDto))]
    [SwaggerResponse(404, "Card not found")]
    public async Task<ActionResult<LostPetAdvertisementDetailsDto>> GetLostPetAdvertisement([FromRoute] Guid petId)
    {
        var query = new GetLostPetAdvertisementDetailsQuery(petId);
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
            request.FirstName, request.PhoneNumber);
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