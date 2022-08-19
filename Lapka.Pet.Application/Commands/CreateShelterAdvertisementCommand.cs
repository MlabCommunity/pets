using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record CreateShelterAdvertisementCommand(Guid PrincipalId, Guid PetId, string Description, string PhoneNumber,
    string FirstName, bool IsVisible) : ICommand;