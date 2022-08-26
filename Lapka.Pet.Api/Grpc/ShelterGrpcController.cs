using Convey.CQRS.Commands;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Lapka.Pet.Application.Commands;

namespace Lapka.Pet.Api.Grpc;

public class ShelterGrpcController : PetService.PetServiceBase //TODO: Nazewnictwo - controller
{
    private readonly ICommandDispatcher _commandDispatcher;

    public ShelterGrpcController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    public override async Task<Empty> CreateShelter(CreateShelterRequest request, ServerCallContext context)
    {
        var command = new CreateShelterCommand(Guid.Parse(request.UserId), request.OrganizationName, request.Street,
            request.ZipCode, request.City, request.Nip, request.Krs);

        await _commandDispatcher.SendAsync(command);

        return new();
    }

    public override async Task<Empty> DeleteShelter(DeleteShelterRequest request, ServerCallContext context)
    {
        var command = new DeleteShelterCommand(Guid.Parse(request.UserId));

        await _commandDispatcher.SendAsync(command);

        return new();
    }

    public override async Task<Empty> AddWorker(AddWorkerRequest request, ServerCallContext context)
    {
        var command = new AddWorkerCommand(Guid.Parse(request.UserId), Guid.Parse(request.WorkerId));

        await _commandDispatcher.SendAsync(command);

        return new();
    }

    public override async Task<Empty> RemoveWorker(RemoveWorkerRequest request, ServerCallContext context)
    {
        var command = new RemoveWorkerCommand(Guid.Parse(request.UserId), Guid.Parse(request.WorkerId));

        await _commandDispatcher.SendAsync(command);

        return new();
    }
}