using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
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

    [HttpPost]
    public async Task CreatePet([FromBody] CreatePetRequest request, [FromQuery] CatBreed? catBreed,
        [FromQuery] CatColor? catColor, [FromQuery] DogBreed? dogBreed, [FromQuery] DogColor? dogColor)
    {
        var ownerId = Guid.NewGuid(); //TOOD get id from principal

        var command = new CreatePetCommand(ownerId, request.Name, request.Gender, request.DateOfBirth,
            request.IsSterilized, request.Weight, "request.Breed", "", request.PetType);
        await _commandDispatcher.SendAsync(command);
    }
}