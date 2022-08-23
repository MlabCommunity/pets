using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record DeleteCardCommand(Guid PetId,Guid PrincipalId): ICommand;