using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdatePetCommand(Guid PetId,string Name, bool IsSterilized, double Weight) : ICommand;
