using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record HideShelterAdvertisementCommand(Guid PrincipalId,Guid PetId) : ICommand;
