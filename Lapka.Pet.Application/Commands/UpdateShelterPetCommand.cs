using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateShelterPetCommand(Guid PrincipalId,Guid PetId, string Name,
bool IsSterilized, double Weight):ICommand;