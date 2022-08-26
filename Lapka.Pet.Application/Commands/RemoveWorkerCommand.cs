using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record RemoveWorkerCommand(Guid UserId, Guid WorkerId) : ICommand;