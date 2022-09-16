using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record PublishShelterPetCommand(Guid PrincipalId, Guid PetId) : ICommand;