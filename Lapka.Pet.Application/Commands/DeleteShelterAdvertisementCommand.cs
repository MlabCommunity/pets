using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record DeleteShelterAdvertisementCommand(Guid PrincipalId, Guid PetId) : ICommand;