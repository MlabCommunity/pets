using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record DeleteShelterPetCommand(Guid PrincipalId,Guid PetId) : ICommand;