using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    [Authorize(Roles = "Shelter")]
    [HttpPut]
    [SwaggerOperation(description: "Updates shelter")]
    [SwaggerResponse(204)]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> UpdateShelter([FromBody] UpdateShelterRequest request)
    {
        var command = new UpdateShelterCommand(GetPrincipalId(), request.Longitude,request.Latitude,request.PhoneNumber,
            request.OrganizationName, request.Krs, request.Nip);

        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpGet]
    [SwaggerOperation(description: "Gets shelter data")]
    [SwaggerResponse(200, "shelter found", typeof(ShelterDto))]
    [SwaggerResponse(404, "shelter not found")]
    public async Task<ActionResult<ShelterDto>> GetShelter()
    {
        var query = new GetShelterQuery(GetPrincipalId());

        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpGet("details/{shelterId:guid}")]
    [SwaggerOperation(description: "Gets shelter data")]
    [SwaggerResponse(200, "shelter found", typeof(ShelterDetailsDto))]
    [SwaggerResponse(404, "shelter not found")]
    public async Task<ActionResult<ShelterDetailsDto>> GetShelterDetails([FromRoute] Guid shelterId)
    {
        var query = new GetShelterDetailsQuery(shelterId);
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [Authorize(Roles = "Shelter")]
    [HttpPost("workers/{workerEmail}")]
    [SwaggerOperation(description: "Adds worker to shelter")]
    [SwaggerResponse(204, "Worker added")]
    [SwaggerResponse(404, "shelter not found")]
    public async Task<IActionResult> AddWorker([FromRoute] string workerEmail)
    {
        var command = new AddWorkerCommand(GetPrincipalId(), workerEmail);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Roles = "Shelter")]
    [HttpDelete("workers/{workerId:guid}")]
    [SwaggerOperation(description: "Deletes worker to shelter")]
    [SwaggerResponse(204, "Worker deleted")]
    [SwaggerResponse(404, "shelter or worker not found")]
    public async Task<IActionResult> RemoveWorker([FromRoute] Guid workerId)
    {
        var command = new RemoveWorkerCommand(GetPrincipalId(), workerId);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpPost("cards/dog")]
    [SwaggerOperation(description: "Creates shelter's card")]
    [SwaggerResponse(204, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> CreateDog([FromBody] CreateDogRequest request)
    {
        var command = new CreateShelterDogCommand(GetPrincipalId(),request.ProfilePhotoId,request.Description,request.IsVisible, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.DogColor, request.DogBreed, request.Photos);

        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpPost("cards/cat")]
    [SwaggerOperation(description: "Creates shelter's card")]
    [SwaggerResponse(204, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> CreateCat([FromBody] CreateCatRequest request)
    {
        var command = new CreateShelterCatCommand(GetPrincipalId(),request.ProfilePhotoId,request.Description,request.IsVisible, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed, request.Photos);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpPost("cards/other")]
    [SwaggerOperation(description: "Creates shelter's card")]
    [SwaggerResponse(204, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> CreateOtherPet([FromBody] CreateOtherPetRequest request)
    {
        var command = new CreateShelterOtherPetCommand(GetPrincipalId(),request.ProfilePhotoId,request.Description,request.IsVisible, request.Name, request.Gender,
            request.DateOfBirth,
            request.IsSterilized, request.Weight, request.Photos);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpPut("cards")]
    [SwaggerOperation(description: "Updates shelter's card")]
    [SwaggerResponse(204, "Card created")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> UpdateShelterCard([FromBody] UpdateShelterPetRequest request)
    {
        var command = new UpdateShelterPetCommand(GetPrincipalId(),  request.PetId, request. Description,request.PetName,request.IsSterilized,request.Weight);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpDelete("cards/{petId:guid}")]
    [SwaggerOperation(description: "Deletes shelter's card")]
    [SwaggerResponse(204, "Card deleted")]
    public async Task<IActionResult> DeleteShelterCard([FromRoute] Guid petId)
    {
        var command = new DeleteShelterPetCommand(GetPrincipalId(), petId);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpGet("cards")]
    [SwaggerOperation(description: "Gets shelter's pets")]
    [SwaggerResponse(200, "Pets found or returns empty list", typeof(Application.Dto.PagedResult<PetDto>))]
    public async Task<ActionResult<Application.Dto.PagedResult<PetDto>>> GetAllShelterPets(
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllShelterPetsQuery(GetPrincipalId(), pageNumber, pageSize);
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }
    
    [Authorize(Policy = "IsWorker")]
    [HttpPut("cards/publish/{petId:guid}")]
    [SwaggerOperation(description: "Publishes pet")]
    [SwaggerResponse(204, "Pet published")]
    [SwaggerResponse(404, "If pet not found")]
    public async Task<IActionResult> PublishAdvertisement([FromRoute] Guid petId)
    {
        var command = new PublishShelterPetCommand(GetPrincipalId(), petId);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpPut("cards/hide/{petId:guid}")]
    [SwaggerOperation(description: "Hides pet")]
    [SwaggerResponse(204, "pet hided")]
    [SwaggerResponse(404, "If pet not found")]
    public async Task<IActionResult> HideAdvertisement([FromRoute] Guid petId)
    {
        var command = new HideShelterPetCommand(GetPrincipalId(), petId);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Roles = "Shelter")]
    [HttpPut("volunteering")]
    [SwaggerOperation(description: "Updates shelter's volunteering")]
    [SwaggerResponse(204, "Volunteering updated")]
    [SwaggerResponse(400, "If data are invalid")]
    public async Task<IActionResult> UpdateVolunteering([FromBody] UpdateVolunteeringRequest request)
    {
        var command = new UpdateVolunteeringCommand(GetPrincipalId(), request.BankAccountNumber,
            request.DonationDescription, request.DailyHelpDescription, request.TakingDogsOutDescription,
            request.IsDonationActive, request.IsDailyHelpActive, request.IsTakingDogsOutActive);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }


    [HttpGet("volunteering/{shelterId:guid}")]
    [SwaggerOperation(description: "Gets shelter's volunteering")]
    [SwaggerResponse(200, "Volunteering data found", typeof(VolunteeringDto))]
    [SwaggerResponse(404, "If shelter not found")]
    public async Task<ActionResult<VolunteeringDto>> GetVolunteering([FromRoute] Guid shelterId)
    {
        var query = new GetVolunteeringQuery(shelterId);
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [Authorize(Roles = "User,Worker")]
    [HttpPost("volunteers/{shelterId:guid}")]
    [SwaggerOperation(description: "Adds Principal user as volunteer to shelter")]
    [SwaggerResponse(204, "Volunteer added")]
    public async Task<IActionResult> AddVolunteer([FromRoute] Guid shelterId)
    {
        var command = new AddVolunteerCommand(GetPrincipalId(), shelterId);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    
    [Authorize(Roles = "User")]
    [HttpGet("volunteers/{longitude:double}/{latitude:double}")]
    [SwaggerOperation(description: "Gets shelters list")]
    [SwaggerResponse(200, "Returns list of shelters")]
    public async Task<ActionResult<Application.Dto.PagedResult<ShelterDto>>> GetShelterList([FromRoute] double longitude,[FromRoute] double latitude)
    {
        var query = new GetAllSheltersQuery(longitude,latitude);
        var result =await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }

    [Authorize]
    [HttpDelete("volunteers/{shelterId:guid}")]
    [SwaggerOperation(description: "Removes Principal user as volunteer from shelter")]
    [SwaggerResponse(204, "Volunteer added")]
    [SwaggerResponse(404, "If shelter or user not found")]
    public async Task<IActionResult> DeleteVolunteer([FromRoute] Guid shelterId)
    {
        var command = new RemoveVolunteerCommand(GetPrincipalId(), shelterId);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Policy = "IsWorker")]
    [HttpGet("volunteers")]
    [SwaggerOperation(description: "Gets shelter's volunteers")]
    [SwaggerResponse(200, "Volunteers found or returns empty list", typeof(List<VolunteerDto>))]
    public async Task<ActionResult<List<VolunteerDto>>> GetVolunteers()
    {
        var query = new GetVolunteersQuery(GetPrincipalId());
        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }
    
    [Authorize(Roles = "Shelter")]
    [HttpGet("workers")]
    [SwaggerOperation(description: "Gets shelter's workers")]
    [SwaggerResponse(200, "workers found or returns empty list", typeof(List<WorkerDto>))]
    public async Task<ActionResult<List<WorkerDto>>> GetWorkers()
    {
        var query = new GetWorkersQuery(GetPrincipalId());

        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }

    [Authorize(Policy = "IsWorker")]
    [HttpGet("stats")]
    [SwaggerOperation(description: "Gets shelter's stats")]
    [SwaggerResponse(200, "", typeof(StatsDto))]
    public async Task<ActionResult<StatsDto>> GetShelterStats()
    {
        var query = new GetShelterStatsQuery(GetPrincipalId());

        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }
}