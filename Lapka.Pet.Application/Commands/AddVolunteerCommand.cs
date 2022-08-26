using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record AddVolunteerCommand(Guid PrincipalId, string PrincipalEmail, Guid ShelterId) : ICommand;