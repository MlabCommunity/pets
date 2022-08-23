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
    public async Task<ActionResult<List<ShelterAdvertisementDto>>> GetAllShelterAdvertisement()
    {
        var query = new GetAllShelterAdvertisementQuery();

        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [Authorize]
    [HttpPost("dog")]
    public async Task<IActionResult> CreateLostDog([FromBody] CreateLostDogAdvertisementRequest request)
    {
        var petCommand = new CreateLostDogCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.DogColor, request.DogBreed);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance);

        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [Authorize]
    [HttpPost("cat")]
    public async Task<IActionResult> CreateLostCat([FromBody] CreateLostCatAdvertisementRequest request)
    {
        var petCommand = new CreateLostCatCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance);
        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [Authorize]
    [HttpPost("other")]
    public async Task<IActionResult> CreateLostOtherPet([FromBody] CreateLostOtherPetAdvertisementRequest request)
    {
        var petCommand = new CreateLostOtherPetCommand(GetPrincipalId(), request.Name, request.Gender,
            request.DateOfBirth,
            request.IsSterilized, request.Weight);

        await _commandDispatcher.SendAsync(petCommand);
        var petId = _userCacheStorage.GetPetId(GetPrincipalId());
        var advertisementCommand = new CreateLostPetAdvertisementCommand(petId, request.Description, request.IsVisible,
            request.DateOfDisappearance, request.CityOfDisappearance, request.StreetOfDisappearance);
        await _commandDispatcher.SendAsync(advertisementCommand);
        return NoContent();
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<LostPetAdvertisementDto>>> GetAllLostPetAdvertisement()
    {
        var query = new GetAllLostPetAdvertisementQuery();
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }
}