using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record ArchiveShelterPetCommand(Guid PetId, Guid PrincipalId) : ICommand;