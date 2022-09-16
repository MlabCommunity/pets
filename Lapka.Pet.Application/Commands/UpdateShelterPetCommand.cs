using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateShelterPetCommand(Guid PrincipalId, Guid PetId, string Description,string PetName,bool IsSterilized,double Weight) : ICommand;