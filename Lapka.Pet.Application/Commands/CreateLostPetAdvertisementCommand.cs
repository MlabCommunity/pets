using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record CreateLostPetAdvertisementCommand(Guid PetId, string Description, string FirstName, string PhoneNumber,
    bool IsVisible,
    DateTime DateOfDisappearance,
    string CityOfDisappearance, string StreetOfDisappearance, Guid PrincipalId) : ICommand;