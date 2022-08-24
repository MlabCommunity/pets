using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdatePetCommand(Guid PetId,Guid PrincipalId, string Name, bool IsSterilized, double Weight) : ICommand;