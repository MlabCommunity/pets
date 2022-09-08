using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record AddWorkerCommand(Guid ShelterId, Guid WorkerId) : ICommand;