using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record RemoveVolunteerCommand(Guid PrincipalId, Guid ShelterId) : ICommand;