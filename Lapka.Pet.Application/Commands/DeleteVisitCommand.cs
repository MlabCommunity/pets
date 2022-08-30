using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record DeleteVisitCommand(Guid PetId, Guid VisitId,Guid PrincipalId) : ICommand;