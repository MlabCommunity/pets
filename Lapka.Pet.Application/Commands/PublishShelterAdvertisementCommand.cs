using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record PublishShelterAdvertisementCommand(Guid PrincipalId, Guid PetId) : ICommand;