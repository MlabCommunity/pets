using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Lapka.Pet.Api.Controllers;

public class PetController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public PetController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }


    [HttpPost("dog")]
    public async Task<IActionResult> CreateDog([FromBody] CreateDogRequest request)
    {
        var ownerId = Guid.NewGuid(); //TOOD get id from principal

        var command = new CreateDogCommand(ownerId, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.DogColor, request.DogBreed);

        await _commandDispatcher.SendAsync(command);

        return NoContent();
    }

    [HttpPost("cat")]
    public async Task<IActionResult> CreatePet([FromBody] CreateCatRequest request)
    {
        var ownerId = Guid.NewGuid(); //TOOD get id from principal

        var command = new CreateCatCommand(ownerId, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, request.CatColor, request.CatBreed);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [HttpPost("other")]
    public async Task<IActionResult> CreateOtherPet([FromBody] CreateOtherPetRequest request)
    {
        var ownerId = Guid.NewGuid(); //TOOD get id from principal

        var command = new CreateOtherPetCommand(ownerId, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePet([FromBody] UpdatePetRequest request)
    {
        var command = new UpdatePetCommand(request.PetId, request.Name, request.IsSterilized, request.Weight);

        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPet(Guid id)
    {
        var query = new GetPetQuery(id);
        var pet = await _queryDispatcher.QueryAsync(query);

        return Ok(pet);
    }
}