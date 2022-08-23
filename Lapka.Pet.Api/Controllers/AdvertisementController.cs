using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Commands.Handlers;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Infrastructure.CacheStorage;
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

    [Authorize(Roles = "Shelter,Worker,User")]
    [HttpGet("shelter")]
    [SwaggerOperation(description: "Gets shelter advertisements")]
    [SwaggerResponse(200, "advertisements found", typeof(List<ShelterAdvertisementDto>))]
    public async Task<ActionResult<List<ShelterAdvertisementDto>>> GetAllShelterAdvertisement()
    {
        var query = new GetAllShelterAdvertisementQuery();

        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }

    [Authorize]
    [HttpPost("dog")]
    [SwaggerOperation(description: "Creates lost pet's card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    [SwaggerResponse(404, "If shelter not found")]
    public async Task<IActionResult> CreateLostDog([FromBody] CreateLostDogAdvertisementRequest request)
    {
        var petCommand = new CreateLostDogCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.DogColor, request.DogBreed);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance,GetPrincipalId());

        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [Authorize]
    [HttpPost("cat")]
    [SwaggerOperation(description: "Creates lost pet's card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    [SwaggerResponse(404, "If shelter not found")]
    public async Task<IActionResult> CreateLostCat([FromBody] CreateLostCatAdvertisementRequest request)
    {
        var petCommand = new CreateLostCatCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance,GetPrincipalId());
        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [Authorize]
    [HttpPost("other")]
    [SwaggerOperation(description: "Creates lost pet's card")]
    [SwaggerResponse(200, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    [SwaggerResponse(404, "If shelter not found")]
    public async Task<IActionResult> CreateLostOtherPet([FromBody] CreateLostOtherPetAdvertisementRequest request)
    {
        var petCommand = new CreateLostOtherPetCommand(GetPrincipalId(), request.Name, request.Gender,
            request.DateOfBirth,
            request.IsSterilized, request.Weight);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance,GetPrincipalId());
        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation(description: "get all lost pet's card")]
    [SwaggerResponse(200, "Cards found", typeof(List<LostPetAdvertisementDto>))]
    public async Task<ActionResult<List<LostPetAdvertisementDto>>> GetAllLostPetAdvertisement()
    {
        var query = new GetAllLostPetAdvertisementQuery();
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }

    [HttpGet("{petId:guid}")]
    public async Task<ActionResult<LostPetAdvertisementDto>> GetLostPetAdvertisement([FromRoute] Guid petId)
    {
        var query = new GetLostPetAdvertisementQuery(petId);
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }

    [Authorize]
    [HttpPut("{petId:guid}")]
    public async Task<IActionResult> UpdateLostPetAdvertisement([FromRoute] Guid petId,
        [FromBody] UpdateLostPetAdvertisementRequest request)
    {
        var command = new UpdateLostPetAdvertisementCommand(petId,GetPrincipalId(),request.Description,request.Name,request.IsSterilized,request.Weight);
        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }
    
    [HttpDelete("{petId:guid}")]
    public async Task<IActionResult> DeleteLostPetAdvertisement([FromRoute] Guid petId)
    {
        var command = new DeleteLostPetAdvertisementCommand(petId, GetPrincipalId());
        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }
}