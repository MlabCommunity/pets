using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UnLikePetCommand(Guid PrincipalId, Guid PetId) : ICommand;
