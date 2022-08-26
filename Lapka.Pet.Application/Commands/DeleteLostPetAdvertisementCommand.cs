using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record DeleteLostPetAdvertisementCommand(Guid PetId, Guid PrincipalId) : ICommand;