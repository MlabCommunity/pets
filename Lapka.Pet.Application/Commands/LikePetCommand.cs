using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record LikePetCommand(Guid PrincipalId,Guid PetId) : ICommand;