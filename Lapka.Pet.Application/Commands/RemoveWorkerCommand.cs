using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record RemoveWorkerCommand(Guid ShelterId, Guid WorkerId) : ICommand;