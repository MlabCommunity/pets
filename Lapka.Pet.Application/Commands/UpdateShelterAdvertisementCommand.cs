using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateShelterAdvertisementCommand(Guid PrincipalId, Guid PetId, string Description) : ICommand;