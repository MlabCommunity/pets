using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record AddVolunteerCommand(Guid PrincipalId, Guid ShelterId) : ICommand;