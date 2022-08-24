using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateLostPetAdvertisementCommand(Guid PetId,Guid PrincipalId,string Description) : ICommand;