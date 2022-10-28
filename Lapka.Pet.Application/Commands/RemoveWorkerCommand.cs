using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record RemoveWorkerCommand(Guid ShelterOwnerId, Guid WorkerId) : ICommand;