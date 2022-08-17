using System.Text.Json;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Infrastructure.Database.Queries;
using Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;
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

    [Authorize(Roles = "Shelter")]
    [HttpPut]
    public async Task<IActionResult> UpdateShelter([FromBody] UpdateShelterRequest request)
    {
        var command = new UpdateShelterCommand(GetPrincipalId(), request.Street, request.Street, request.ZipCode,
            request.OrganizationName, request.Krs, request.Nip);

        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }

    [Authorize(Roles = "Shelter")]
    [HttpGet]
    public async Task<ActionResult<ShelterDto>> GetShelter()
    {
        var query = new GetShelterQuery(GetPrincipalId());

        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [Authorize(Roles = "Shelter")]
    [HttpPost("card/dog")]
    public async Task<IActionResult> CreateDog([FromBody] CreateDogRequest request)
    {
        var command = new CreateShelterDogCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.DogColor, request.DogBreed);

        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }

    [Authorize(Roles = "Shelter")]
    [HttpPost("card/cat")]
    public async Task<IActionResult> CreateCat([FromBody] CreateCatRequest request)
    {
        var command = new CreateShelterCatCommand(GetPrincipalId(), request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize(Roles = "Shelter")]
    [HttpPost("card/other")]
    public async Task<IActionResult> CreateOtherPet([FromBody] CreateOtherPetRequest request)
    {
        var command = new CreateShelterOtherPetCommand(GetPrincipalId(), request.Name, request.Gender,
            request.DateOfBirth,
            request.IsSterilized, request.Weight);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [Authorize]
    [HttpGet("pets")]
    public async Task<ActionResult<List<PetDto>>> GetAllShelterPets()
    {
        var query = new GetAllShelterPetsQuery(GetPrincipalId());
        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }

    [Authorize(Roles = "Shelter")]
    [HttpPut("volunteering")]
    public async Task<IActionResult> UpdateVolunteering([FromBody] UpdateVolunteeringRequest request)
    {
        var command = new UpdateVolunteeringCommand(GetPrincipalId(), request.BankAccountNumber,
            request.DonationDescription, request.DailyHelpDescription, request.TakingDogsOutDescription,
            request.IsDonationActive, request.IsDailyHelpActive, request.IsTakingDogsOutActive);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    
    [Authorize(Roles = "Shelter,Worker")]
    [HttpGet("volunteering")]
    public async Task<ActionResult<VolunteeringDto>> GetVolunteering()
    {
        var query = new GetVolunteeringQuery(GetPrincipalId());
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }
    
    [Authorize]
    [HttpPost("volunteers/{shelterId:guid}")]
    public async Task<IActionResult> AddVolunteer([FromRoute] Guid shelterId)
    {
        var command = new AddVolunteerCommand(GetPrincipalId(),GetPrincipalEmail() ,shelterId);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    
    [Authorize]
    [HttpDelete("volunteers/{shelterId:guid}")]
    public async Task<IActionResult> DeleteVolunteer([FromRoute] Guid shelterId)
    {
        var command = new RemoveVolunteerCommand(GetPrincipalId(),shelterId);
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    
    [Authorize(Roles = "Worker,Shelter")]
    [HttpGet("volunteers")]
    public async Task<ActionResult<List<VolunteerDto>>> GetVolunteers()
    {
        var query = new GetVolunteersQuery(GetPrincipalId());
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }
}