using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record DeleteShelterCommand(Guid UserId) : ICommand;