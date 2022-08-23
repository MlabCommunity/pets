using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateLostPetAdvertisementCommand(Guid PetId,Guid PrincipalId,string Description,string Name,bool IsSterilized,double Weight) : ICommand;