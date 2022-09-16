using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record HideShelterPetCommand(Guid PrincipalId, Guid PetId) : ICommand;