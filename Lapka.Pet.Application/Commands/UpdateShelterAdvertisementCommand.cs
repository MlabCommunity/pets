using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateShelterAdvertisementCommand(Guid PrincipalId,Guid AdvertisementId, string Description) : ICommand;